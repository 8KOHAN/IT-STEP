let colors = [];

loadColors();

function saveColor() {

    clearErrors();

    let name = document.getElementById("name").value.trim();
    let type = document.getElementById("type").value;
    let code = document.getElementById("code").value.trim();

    let valid = true;

    if (name === "") {
        showError("nameError", "Name is required");
        valid = false;
    }

    if (!/^[A-Za-zА-Яа-яІіЇїЄє]+$/.test(name)) {
        showError("nameError", "Only letters allowed");
        valid = false;
    }

    let exists = colors.some(
        c => c.name.toLowerCase() === name.toLowerCase()
    );

    if (exists) {
        showError("nameError", "Name already exists");
        valid = false;
    }


    if (type === "RGB") {

        let rgbRegex =
            /^([0-9]{1,3}),([0-9]{1,3}),([0-9]{1,3})$/;

        if (!rgbRegex.test(code)) {
            showError("codeError", "RGB format: 255,255,255");
            valid = false;
        }
        else {
            let nums = code.split(",");

            for (let n of nums) {
                if (+n < 0 || +n > 255) {
                    showError(
                        "codeError",
                        "RGB values must be 0-255"
                    );
                    valid = false;
                }
            }
        }
    }

    if (type === "RGBA") {

        let rgbaRegex =
            /^([0-9]{1,3}),([0-9]{1,3}),([0-9]{1,3}),(0|1|0?\.[0-9]+)$/;

        if (!rgbaRegex.test(code)) {
            showError(
                "codeError",
                "RGBA format: 255,255,255,0.5"
            );
            valid = false;
        }
        else {

            let arr = code.split(",");

            for (let i = 0; i < 3; i++) {
                if (+arr[i] < 0 || +arr[i] > 255) {
                    showError(
                        "codeError",
                        "RGBA values must be 0-255"
                    );
                    valid = false;
                }
            }

            let alpha = parseFloat(arr[3]);

            if (alpha < 0 || alpha > 1) {
                showError(
                    "codeError",
                    "Alpha must be 0-1"
                );
                valid = false;
            }
        }
    }

    if (type === "HEX") {

        let hexRegex =
            /^#[0-9A-Fa-f]{6}$/;

        if (!hexRegex.test(code)) {
            showError(
                "codeError",
                "HEX format: #FF00AA"
            );
            valid = false;
        }
    }

    if (!valid) return;

    colors.push({
        name,
        type,
        code
    });

    saveToCookie();

    renderColors();

    document.getElementById("name").value = "";
    document.getElementById("code").value = "";
}

function renderColors() {

    let palette =
        document.getElementById("palette");

    palette.innerHTML = "";

    colors.forEach(color => {

        let div =
            document.createElement("div");

        div.className = "color-box";

        if (color.type === "RGB") {
            div.style.backgroundColor =
                `rgb(${color.code})`;
        }

        if (color.type === "RGBA") {
            div.style.backgroundColor =
                `rgba(${color.code})`;
        }

        if (color.type === "HEX") {
            div.style.backgroundColor =
                color.code;
        }

        div.innerHTML =
            `<span>${color.name}</span><br><span>${color.type}</span><br><span>${color.code}</span>`;

        palette.appendChild(div);
    });
}

function showError(id, text) {
    document.getElementById(id).innerText = text;
}

function clearErrors() {
    document.getElementById("nameError").innerText = "";
    document.getElementById("codeError").innerText = "";
}

function saveToCookie() {

    let date = new Date();

    date.setHours(date.getHours() + 3);

    document.cookie =
        "colors=" +
        encodeURIComponent(JSON.stringify(colors)) +
        ";expires=" +
        date.toUTCString() +
        ";path=/";
}

function loadColors() {
    let cookie =
        document.cookie
            .split("; ")
            .find(row =>
                row.startsWith("colors="));

    if (cookie) {

        colors = JSON.parse(
            decodeURIComponent(
                cookie.split("=")[1]
            )
        );

        renderColors();
    }
}
