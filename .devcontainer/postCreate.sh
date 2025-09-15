#!/usr/bin/env bash
set -euo pipefail

log() { printf "[postCreate] %s\n" "$*"; }

PY="$(command -v python3 || command -v python)"
log "Using Python: $PY ($( $PY -V ))"

log "Upgrading pip"
$PY -m pip install --upgrade pip

if [ -f requirements.txt ]; then
  log "Installing requirements.txt"
  $PY -m pip install -r requirements.txt
else
  log "No requirements.txt found, skipping"
fi

log "Installing core tools (jupyterlab, ipykernel, openai)"
$PY -m pip install jupyterlab ipykernel openai

log "Registering Jupyter kernel 'rag-env'"
$PY -m ipykernel install --user --name rag-env --display-name "Python (RAG Env)"

log "Done"