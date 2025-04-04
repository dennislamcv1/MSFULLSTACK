// script.js

document.addEventListener('DOMContentLoaded', function() {
    const hamburgerIcon = document.querySelector('.hamburger-icon');
    const mainNav = document.querySelector('nav[role="navigation"]'); // Updated selector

    if (hamburgerIcon && mainNav) {
        hamburgerIcon.addEventListener('click', toggleMenu);

        function toggleMenu() {
            mainNav.classList.toggle('nav-open');
        }
    } else {
        console.error("Hamburger icon or navigation menu not found in the HTML.");
    }
});