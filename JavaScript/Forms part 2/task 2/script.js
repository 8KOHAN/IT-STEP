document.getElementById("registerForm").addEventListener("submit", function (e) {
    e.preventDefault();

    let pass1 = document.getElementById("pass1").value;
    let pass2 = document.getElementById("pass2").value;

    if (pass1 !== pass2) {
        alert("Passwords do not match");
        return;
    }

    let email = document.getElementById("email").value;

    document.getElementById("result").innerText =
        `A confirmation email has been sent to ${email}`;
});
