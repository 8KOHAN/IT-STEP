function login() {
    let name = document.getElementById("name").value;
    let remember = document.getElementById("remember").checked;

    document.getElementById("result").innerText =
        `Hello, ${name}! I'm ${remember ? "remembered" : "not remembered"}`;
}
