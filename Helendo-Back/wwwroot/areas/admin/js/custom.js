const roleChanger = document.querySelectorAll(".role-changer");

console.log("hell");

roleChanger.forEach(n => n.addEventListener("change", async function () {
    let roleName = this.options[this.selectedIndex].value;
    let userId = $(this).attr("data-userId");

    await fetch(`/admin/user/changerole?roleName=${roleName}&userId=${userId}`);
}));