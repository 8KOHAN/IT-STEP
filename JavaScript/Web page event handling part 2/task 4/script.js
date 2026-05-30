const lights = document.querySelectorAll(".light");
let current = 0;

document.getElementById("nextBtn")
.addEventListener("click", () => {

    lights[current].classList.remove("active");

    current = (current + 1) % lights.length;

    lights[current].classList.add("active");
});
