document.addEventListener("DOMContentLoaded", function() {
    const btnNext = document.querySelector('.btn-content'); 

    btnNext.addEventListener('click', function(event) {
        event.preventDefault(); 
        const images = document.querySelectorAll('.carousel-img'); 
        let activeIndex = Array.from(images).findIndex(image => image.classList.contains('active')); 

        images[activeIndex].classList.remove('active'); 
        activeIndex = (activeIndex + 1) % images.length; 
        images[activeIndex].classList.add('active'); 
    });
});