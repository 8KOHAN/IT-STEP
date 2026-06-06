document.getElementById("messageForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const author = document.getElementById("author").value;
    const text = document.getElementById("text").value;

    const li = document.createElement("li");
    li.innerHTML = `<strong>${author}:</strong> ${text}`;

    document.getElementById("messages").appendChild(li);

    this.reset();
});
