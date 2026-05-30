const tooltip = document.getElementById("tooltip");

document.querySelectorAll(".btn")
.forEach(button => {

    button.addEventListener("mouseenter", () => {

        tooltip.textContent =
            button.dataset.tooltip;

        tooltip.style.display = "block";

        const btnRect =
            button.getBoundingClientRect();

        const tipRect =
            tooltip.getBoundingClientRect();

        let top =
            btnRect.top -
            tipRect.height -
            10;

        let left =
            btnRect.left +
            btnRect.width / 2 -
            tipRect.width / 2;

        if (top < 0) {
            top = btnRect.bottom + 10;
        }

        tooltip.style.top = top + "px";
        tooltip.style.left = left + "px";
    });

    button.addEventListener("mouseleave", () => {
        tooltip.style.display = "none";
    });

});
