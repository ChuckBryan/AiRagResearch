# AI RAG Research - Pluralsight Course (Personal Working Copy)

This repository is my personal working copy as I take the Pluralsight course on **Deploying and Maintaining RAG (Retrieval-Augmented Generation) Systems**. It is not intended for collaboration, sharing, or accepting pull requests. All notes, code, and experiments here are for my own learning and reference.

## Course Overview

This course covers the essential aspects of building, deploying, and maintaining production-ready RAG systems. You'll learn about embeddings, system architecture, management strategies, and best practices for enterprise-level RAG implementations.

## Course Structure

### Module 1: Building and Deploying RAG in Production

**Location:** `01/demos/deploying-maintaining-rag-systems-m1/`

- **m1-01-embeddings.ipynb** - Introduction to embeddings and vector representations
- **m1-02-building-rag-system.ipynb** - Building a complete RAG system from scratch
- **Slides:** `01/building-and-deploying-rag-in-production-slides.pdf`

### Module 2: Managing RAG Systems

**Location:** `02/demos/deploying-maintaining-rag-systems-m2/`

- **m2-01-managing-rag-system.ipynb** - System management and optimization strategies
- **Slides:** `02/managing-rag-systems-slides.pdf`

## Data Sources

Each module includes sample data in the `data/` folder:

- `About.md` - General information and context
- `Bar-AI-Vision.md` - AI vision use case examples
- `Qux-AI-Vision.md` - Additional AI vision scenarios

## Prerequisites

- Python 3.8+
- Jupyter Notebook or JupyterLab
- Basic understanding of machine learning concepts
- Familiarity with Python libraries for data science

## Setup Instructions

1. **Clone the repository:**

   ```bash
   git clone <repository-url>
   cd AiRagResearch
   ```

2. **Install dependencies for Module 1:**

   ```bash
   cd 01/demos/deploying-maintaining-rag-systems-m1/
   pip install -r requirements.txt
   ```

3. **Install dependencies for Module 2:**

   ```bash
   cd 02/demos/deploying-maintaining-rag-systems-m2/
   pip install -r requirements.txt
   ```

4. **Launch Jupyter Notebook:**

   ```bash
   jupyter notebook
   ```

5. **Set your environment variables (required):**

   Create a `.env` file at the repo root (or export variables in your shell). A starter file is provided:

   - Copy `.env.sample` to `.env`
   - Fill in the values:

   ```dotenv
   OPENAI_API_KEY=your_key_here
   ```

   The notebooks load environment variables with `python-dotenv` if present and will error early if `OPENAI_API_KEY` is not set.

## Learning Objectives

By the end of this course, you will be able to:

- ✅ Understand the fundamentals of RAG systems and embeddings
- ✅ Build production-ready RAG systems from scratch
- ✅ Implement effective data ingestion and preprocessing pipelines
- ✅ Deploy RAG systems in cloud environments
- ✅ Monitor and maintain RAG system performance
- ✅ Optimize retrieval accuracy and response quality
- ✅ Handle common challenges in production RAG deployments

## Key Technologies Covered

- **Vector Databases** - Storage and retrieval of embeddings
- **Embedding Models** - Text and document vectorization
- **Language Models** - Generation and reasoning capabilities
- **Retrieval Strategies** - Semantic search and ranking
- **Production Deployment** - Scalability and monitoring
- **System Architecture** - Design patterns for RAG systems

## Best Practices Covered

- Data preprocessing and chunking strategies
- Embedding model selection and fine-tuning
- Retrieval optimization techniques
- Response generation quality improvement
- System monitoring and alerting
- Performance tuning and scaling
- Security and privacy considerations

## Troubleshooting

If you encounter issues:

1. **Dependencies:** Ensure all requirements are installed correctly
2. **Jupyter:** Make sure Jupyter can access the correct Python environment
3. **Data Access:** Verify that data files are in the correct locations
4. **Memory:** Some operations may require sufficient RAM for large embeddings

5. **Secrets / API Keys:** Never hardcode secrets in notebooks. Use environment variables (e.g., `.env`, which is already git-ignored). If a secret is accidentally committed, rotate the key immediately and remove it from history before pushing.

## Contributing

This repository is for my personal use only while following the course. I am not accepting contributions or pull requests.

## Additional Resources

- [Pluralsight Course Link](#) - Link to the actual course
- [RAG Documentation](#) - Additional reading materials
- [Vector Database Comparison](#) - Technology selection guides
- [Production Deployment Guides](#) - Cloud deployment resources

## License

This course material is provided for educational purposes. Please refer to Pluralsight's terms of service for usage guidelines.

---

**Happy Learning!** 🚀

_Last Updated: September 2025_
