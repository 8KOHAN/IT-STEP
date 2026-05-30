const btn = document.getElementById("topBtn");

window.addEventListener("scroll", () => {
    if (window.scrollY > 100) {
        btn.style.display = "block";
    } else {
        btn.style.display = "none";
    }
});

btn.addEventListener("click", () => {
    window.scrollTo({
        top: 0,
        behavior: "smooth"
    });
});
