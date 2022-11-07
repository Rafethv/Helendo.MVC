// Basket

const addBasket = document.querySelectorAll(".add-basket");
const deleteBasket = document.querySelectorAll(".delete-basket");
const basketContainer = document.getElementById("basket-container");

addBasket.forEach(n => n.addEventListener('click', async function () {
    let dataId = $(this).attr('data-id');
    let resp = await fetch(`/cart/addtobasket?id=${dataId}`);
    let data = await resp.text();


    basketContainer.forEach(n => n.innerHTML = data);
}));


deleteBasket.forEach(n => n.addEventListener('click', async function () {
    let dataId = $(this).attr('data-id');
    let resp = await fetch(`/cart/deletefrombasket?id=${dataId}`);
    let data = await resp.text();

    basketContainer.forEach(n => n.innerHTML = data);
}));

// Wishlist

const addWishlist = document.querySelectorAll(".add-wishlist");
const deleteWishlist = document.querySelectorAll(".delete-wishlist");
const wishlistContainer = document.getElementById("wishlist-container");

addWishlist.forEach(n => n.addEventListener('click', async function () {
    console.log("Hello");
    let dataId = this.getAttribute("data-id");
    let resp = await fetch(`/wishlist/addtowishlist?id=${dataId}`);
    let data = await resp.text();

    wishlistContainer.innerHTML = data;
}));

deleteWishlist.forEach(n => n.addEventListener('click', async function () {
    let dataId = $(this).attr('data-id');
    let resp = await fetch(`/wishlist/deletefromwishlist?id=${dataId}`);
    let data = await resp.text();


    wishlistContainer.innerHTML = data;
}));

const productPageNumber = document.querySelectorAll(".product-page");
const productContainer = document.getElementById("product-container");

productPageNumber.forEach(n => n.addEventListener('click', async function () {
    n.classList.add("active-btn");
    let pageId = this.getAttribute("page-id");
    let resp = await fetch(`/product/pagination?page=${pageId}`);
    let data = await resp.text();

    console.log(data);

    productContainer.innerHTML = data;
}));

const blogPageNumber = document.querySelectorAll(".blog-page");
const blogContainer = document.getElementById("blog-container");

blogPageNumber.forEach(n => n.addEventListener('click', async function () {
    n.classList.add("active-btn");
    let pageId = this.getAttribute("page-id");
    let resp = await fetch(`/blog/pagination?page=${pageId}`);
    let data = await resp.text();

    console.log(data);

    blogContainer.innerHTML = data;
}));