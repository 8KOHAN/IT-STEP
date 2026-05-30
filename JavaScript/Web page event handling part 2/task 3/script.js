const field = document.getElementById("field");
const ball = document.getElementById("ball");

field.addEventListener("click", (event) => {

    const fieldRect =
        field.getBoundingClientRect();

    let x =
        event.clientX -
        fieldRect.left -
        ball.offsetWidth / 2;

    let y =
        event.clientY -
        fieldRect.top -
        ball.offsetHeight / 2;

    const maxX =
        field.clientWidth -
        ball.offsetWidth;

    const maxY =
        field.clientHeight -
        ball.offsetHeight;

    x = Math.max(0, Math.min(x, maxX));
    y = Math.max(0, Math.min(y, maxY));

    ball.style.left = x + "px";
    ball.style.top = y + "px";
});
