var getTranslate;
var slideWidth;

var mySwiper = new Swiper('.slider .swiper', {
    speed: 8000,
    slidesPerView: 3,
    loop: true,
    freeMode: true,
    freeModeMomentum: false,
    centeredSlides: true,
    autoplay: {
        delay: 0,
        disableOnInteraction: false,
    }
})

const header = document.querySelector(".header");

window.addEventListener("scroll", () => {
    if (window.scrollY > 100) {
        header.classList.add("scrolled")
    } else {
        header.classList.remove("scrolled")
    }
});

