console.log("localStorage.js is loaded and running");

document.addEventListener('DOMContentLoaded', function () {
    loadCustomisationSettings();
    addEventListeners();
    resetSettings();
});

// Load customisation settings from localStorage
function loadCustomisationSettings() {
    const storedSettings = JSON.parse(localStorage.getItem('customisationSettings')) || {};
  
    // Set default values if settings are not found
    const fontSize = storedSettings.fontSize || 20;
    const navColour = storedSettings.navColour || '#FFFFFF';

    applySettings(fontSize, navColour);
}

function resetSettings() {

    console.log("resetsettings function is running")
    const resetButton = document.getElementById("resetCustomisation");
    if (!resetButton) {
        console.error("Reset button not found!");
        return;
    }

    resetButton.addEventListener("click", function () {
        console.log("Reset button clicked!");

        // Clear localStorage for customization settings
        localStorage.removeItem("customisationSettings");

        // Reset navigation font size to default
        document.querySelectorAll(".nav a").forEach(link => {
            link.style.fontSize = ""; // Reset to default
        });

        // Reset header background color to default
        document.querySelector("header").style.backgroundColor = ""; // Reset to default

        // Optionally, reload the page to ensure all changes are applied
        location.reload();
    });
}
// Apply the customisation settings to the page
function applySettings(fontSize, navColour) {
    document.body.style.fontSize = `${fontSize}px`;

    const navElements = document.querySelectorAll('.nav');
    navElements.forEach(nav => {
        nav.style.backgroundColor = navColour;
    });

    // Pre-set the slider and color picker
    document.getElementById('fontSize').value = fontSize;
    document.getElementById('navColour').value = navColour;
}

// Event listeners to capture customization inputs
function addEventListeners() {
    const fontSizeSlider = document.getElementById('fontSize');
    const navColourInput = document.getElementById('navColour');

    fontSizeSlider.addEventListener('input', function () {
        const fontSize = fontSizeSlider.value;
        document.body.style.fontSize = `${fontSize}px`;
        saveSettings(fontSize, navColourInput.value);
    });

    navColourInput.addEventListener('input', function () {
        const navColour = navColourInput.value;
        const navElements = document.querySelectorAll('.nav');
        navElements.forEach(nav => {
            nav.style.backgroundColor = navColour;
        });
        saveSettings(fontSizeSlider.value, navColour);
    });
}

// Save the customisation settings to localStorage
function saveSettings(fontSize, navColour) {
    const settings = {
        fontSize: fontSize,
        navColour: navColour
    };
    localStorage.setItem('customisationSettings', JSON.stringify(settings));
}