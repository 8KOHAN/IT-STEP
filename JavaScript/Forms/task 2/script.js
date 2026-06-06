function checkAnswers() {
    let score = 0;

    if (document.querySelector('input[name="q1"]:checked')?.value === "true")
        score++;

    if (document.querySelector('input[name="q2"]:checked')?.value === "false")
        score++;

    if (document.querySelector('input[name="q3"]:checked')?.value === "true")
        score++;

    document.getElementById("result").innerHTML =
        `Correct answers: ${score} out of 3`;
}
