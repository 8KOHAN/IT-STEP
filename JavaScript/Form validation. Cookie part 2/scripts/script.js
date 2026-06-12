const form = document.getElementById("form-Registration");

const emailInput = document.getElementById("Email-input");
const passwordInput = document.getElementById("Password-input");
const repeatPasswordInput = document.getElementById("Repeat-Password-input");

const emailLabel = document.getElementById("email-label");
const passwordLabel = document.getElementById("password-label");
const repeatLabel = document.getElementById("repeat-label");

window.addEventListener("load", () => {
    const email = getCookie("email");

    if (email) {
        window.location.href = "userinfo.html";
    }
});

function setCookie(name, value, hours = 1) {
    const date = new Date();

    date.setTime(
        date.getTime() + hours * 60 * 60 * 1000
    );

    document.cookie =
        `${name}=${encodeURIComponent(value)}; expires=${date.toUTCString()}; path=/`;
}

function getCookie(name) {
    const cookies = document.cookie.split("; ");

    for (let cookie of cookies) {
        const [key, value] = cookie.split("=");

        if (key === name) {
            return decodeURIComponent(value);
        }
    }

    return null;
}

function resetLabels() {
    emailLabel.innerHTML = "Email:";
    passwordLabel.innerHTML = "Password:";
    repeatLabel.innerHTML = "Repeat:";
}

form.addEventListener("submit", (e) => {

    e.preventDefault();

    resetLabels();

    let hasErrors = false;

    const emailRegex =
        /^[A-Za-z0-9._-]{3,}@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/;

    if (!emailInput.value.trim()) {

        emailLabel.innerHTML =
            'Email: <span style="color:red">This field is required</span>';

        hasErrors = true;
    }
    else if (!emailRegex.test(emailInput.value.trim())) {

        emailLabel.innerHTML =
            'Email: <span style="color:red">Invalid format</span>';

        hasErrors = true;
    }

    const passwordRegex =
        /^(?=.*[a-zа-яё])(?=.*[A-ZА-ЯЁ])(?=.*\d).{6,}$/u;

    if (!passwordInput.value) {

        passwordLabel.innerHTML =
            'Password: <span style="color:red">This field is required</span>';

        hasErrors = true;
    }
    else if (!passwordRegex.test(passwordInput.value)) {

        passwordLabel.innerHTML =
            'Password: <span style="color:red">At least 6 characters, one uppercase letter, one lowercase letter and one number</span>';

        hasErrors = true;
    }

    if (!repeatPasswordInput.value) {

        repeatLabel.innerHTML =
            'Repeat: <span style="color:red">This field is required</span>';

        hasErrors = true;
    }
    else if (
        passwordInput.value !== repeatPasswordInput.value
    ) {

        repeatLabel.innerHTML =
            'Repeat: <span style="color:red">Passwords do not match</span>';

        hasErrors = true;
    }

    if (hasErrors) {
        return;
    }

    setCookie("email", emailInput.value.trim());
    setCookie("password", passwordInput.value);

    window.location.href = "userinfo.html";
});
