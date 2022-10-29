const menuOpen = document.querySelector(".menu-open-button");
const menuClose = document.querySelector(".menu-close-button");
const menuModal = document.querySelector(".menu-modal");

menuOpen.addEventListener("click", function () {
    menuModal.classList.add("active");
});

menuClose.addEventListener("click", function () {
    menuModal.classList.remove("active");
});
