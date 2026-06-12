const form = document.getElementById("form-info");

const firstNameInput = document.getElementById("FirstName-input");
const lastNameInput = document.getElementById("LastName-input");
const yearInput = document.getElementById("Year-of-birth-input");
const genderInput = document.getElementById("choice-gender");
const phoneInput = document.getElementById("Phone-number-input");
const telegramInput = document.getElementById("Telegram-input");
const exitBtn = document.getElementById("exit-btn");

const firstNameLabel = document.getElementById("firstname-label");
const lastNameLabel = document.getElementById("lastname-label");
const yearLabel = document.getElementById("year-label");
const phoneLabel = document.getElementById("phone-label");
const telegramLabel = document.getElementById("telegram-label");

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

function deleteCookie(name) {
    document.cookie =
        `${name}=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/`;
}

function resetLabels() {
    firstNameLabel.innerHTML = "First Name:";
    lastNameLabel.innerHTML = "Last Name:";
    yearLabel.innerHTML = "Year of birth:";
    phoneLabel.innerHTML = "Phone number:";
    telegramLabel.innerHTML = "Telegram:";
}

window.addEventListener("load", () => {

    const email = getCookie("email");

    if (!email) {
        window.location.href = "index.html";
        return;
    }

    firstNameInput.value =
        getCookie("firstName") || "";

    lastNameInput.value =
        getCookie("lastName") || "";

    yearInput.value =
        getCookie("year") || "";

    genderInput.value =
        getCookie("gender") || "Male";

    phoneInput.value =
        getCookie("phone") || "";

    telegramInput.value =
        getCookie("telegram") || "";
});

exitBtn.addEventListener("click", () => {

    const cookies = document.cookie.split(";");

    for (let cookie of cookies) {

        const name = cookie.split("=")[0].trim();

        deleteCookie(name);
    }

    window.location.href = "index.html";
});

form.addEventListener("submit", (e) => {

    e.preventDefault();

    resetLabels();

    let hasErrors = false;

    if (
        !/^[A-Za-zА-Яа-яЁёІіЇїЄє]{1,20}$/.test(
            firstNameInput.value.trim()
        )
    ) {
        firstNameLabel.innerHTML =
            'First Name: <span style="color:red">only letters, max 20 characters</span>';

        hasErrors = true;
    }

    if (
        !/^[A-Za-zА-Яа-яЁёІіЇїЄє]{1,20}$/.test(
            lastNameInput.value.trim()
        )
    ) {
        lastNameLabel.innerHTML =
            'Last Name: <span style="color:red">only letters, max 20 characters</span>';

        hasErrors = true;
    }

    const currentYear = new Date().getFullYear();
    const year = Number(yearInput.value);

    if (
        isNaN(year) ||
        year < 1900 ||
        year > currentYear
    ) {
        yearLabel.innerHTML =
            `Year of birth: <span style="color:red">1900 - ${currentYear}</span>`;

        hasErrors = true;
    }

    if (phoneInput.value.trim()) {

        const phoneRegex =
            /^[0-9()\-\s]+$/;

        const digits =
            phoneInput.value.replace(/\D/g, "");

        if (
            !phoneRegex.test(phoneInput.value) ||
            digits.length < 10 ||
            digits.length > 12
        ) {
            phoneLabel.innerHTML =
                '<span style="color:red">Phone number: 10-12 digits</span>';

            hasErrors = true;
        }
    }

    if (
        telegramInput.value.trim() &&
        !/^[A-Za-z0-9._-]+$/.test(
            telegramInput.value.trim()
        )
    ) {
        telegramLabel.innerHTML =
            '<span style="color:red">Telegram: invalid format</span>';

        hasErrors = true;
    }

    if (hasErrors) {
        return;
    }

    setCookie(
        "firstName",
        firstNameInput.value.trim()
    );

    setCookie(
        "lastName",
        lastNameInput.value.trim()
    );

    setCookie(
        "year",
        yearInput.value.trim()
    );

    setCookie(
        "gender",
        genderInput.value
    );

    setCookie(
        "phone",
        phoneInput.value.trim()
    );

    setCookie(
        "telegram",
        telegramInput.value.trim()
    );

    alert("Data saved successfully!")
});
