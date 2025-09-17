// Handle Bootstrap Offcanvas interactions
let dotNetInstance = null;

// Add a debug function to check Bootstrap availability
window.checkBootstrap = function() {
    console.log("Checking Bootstrap availability");
    if (typeof bootstrap !== 'undefined') {
        console.log("Bootstrap is available, version:", bootstrap.Offcanvas.VERSION);
        return true;
    } else {
        console.error("Bootstrap is not defined");
        return false;
    }
};

window.initOffcanvas = function (instance, el) {
    console.log("initOffcanvas called");
    // Store the .NET instance for callbacks
    dotNetInstance = instance;
    
    try {
    // Use provided element reference if available
    const offcanvasElement = el || document.getElementById('movieDetailOffcanvas');
        if (!offcanvasElement) {
            console.error("Offcanvas element not found");
            return;
        }
        
        // Check Bootstrap availability
        window.checkBootstrap();
        
        // Add event listener to handle when the offcanvas is hidden
    offcanvasElement.addEventListener('hidden.bs.offcanvas', function () {
            console.log("Offcanvas hidden event triggered");
            if (dotNetInstance) {
                dotNetInstance.invokeMethodAsync('HandleOffcanvasHidden');
            }
        });
        
        console.log("Offcanvas event listener attached successfully");
    } catch (error) {
        console.error("Error initializing offcanvas:", error);
    }
};

// Show the offcanvas
window.showOffcanvas = function (el) {
    console.log("showOffcanvas called");
    try {
    const offcanvasElement = el || document.getElementById('movieDetailOffcanvas');
        if (!offcanvasElement) {
            console.error("Offcanvas element not found");
            return;
        }
        
        if (!window.checkBootstrap()) {
            return;
        }
        
        let bsOffcanvas = bootstrap.Offcanvas.getInstance(offcanvasElement);
        if (!bsOffcanvas) {
            bsOffcanvas = new bootstrap.Offcanvas(offcanvasElement);
        }
        bsOffcanvas.show();
        console.log("Offcanvas show method called");
    } catch (error) {
        console.error("Error showing offcanvas:", error);
    }
};

// Hide the offcanvas
window.hideOffcanvas = function (el) {
    console.log("hideOffcanvas called");
    try {
    const offcanvasElement = el || document.getElementById('movieDetailOffcanvas');
        if (!offcanvasElement) {
            console.error("Offcanvas element not found");
            return;
        }
        
        if (!window.checkBootstrap()) {
            return;
        }
        
        const bsOffcanvas = bootstrap.Offcanvas.getInstance(offcanvasElement);
        if (bsOffcanvas) {
            bsOffcanvas.hide();
            console.log("Offcanvas hide method called");
        } else {
            console.warn("No offcanvas instance found");
        }
    } catch (error) {
        console.error("Error hiding offcanvas:", error);
    }
};
