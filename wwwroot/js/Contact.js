document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('contactForm');
    form.addEventListener('submit', (event) => {
        event.preventDefault();
        
        const email = document.getElementById('email').value;
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    
        if (!emailRegex.test(email)) {
            alert('Please enter a valid email address.')
            return;
        }
    
        alert('Successfully Submitted.')
    });
});