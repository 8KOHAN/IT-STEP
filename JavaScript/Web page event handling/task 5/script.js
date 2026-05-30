const items = document.querySelectorAll(".menu-item");

items.forEach(item => {
    item.addEventListener("click", () => {

        items.forEach(i => {
            if (i !== item) i.classList.remove("active");
        });

        item.classList.toggle("active");
    });
});
