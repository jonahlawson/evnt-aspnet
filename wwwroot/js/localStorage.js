document.addEventListener('DOMContentLoaded', function () {
    loadCustomisationSettings();
    addEventListeners();
});

// Load customisation settings from localStorage
function loadCustomisationSettings() {
    const storedSettings = JSON.parse(localStorage.getItem('customisationSettings')) || {};
  
    // Set default values if settings are not found
    const fontSize = storedSettings.fontSize || 20;
    const navColour = storedSettings.navColour || '#FFFFFF';

    applySettings(fontSize, navColour);
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
