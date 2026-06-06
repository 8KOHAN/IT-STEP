let test = [];

function addQuestion() {

    let question = document.getElementById("question").value;
    let correct = document.getElementById("correct").value;
    let wrong = document.getElementById("wrong").value;

    test.push({
        question,
        correct,
        wrong
    });

    let li = document.createElement("li");

    li.innerHTML = `
        <b>${question}</b><br>
        correct: ${correct}<br>
        wrong: ${wrong}
    `;

    document.getElementById("questions").appendChild(li);

    document.getElementById("question").value = "";
    document.getElementById("correct").value = "";
    document.getElementById("wrong").value = "";
}
