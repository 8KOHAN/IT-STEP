const input = document.getElementById("jsonInput");
const result = document.getElementById("result");
const button = document.getElementById("formatBtn");

button.addEventListener("click", () => {

    try {
        const jsonObject = JSON.parse(input.value);

        const formattedJson =
            JSON.stringify(jsonObject, null, 4);

        result.textContent = formattedJson;
        result.classList.remove("error");
    }
    catch (error) {
        result.textContent =
            "Error: The input is not valid JSON.";
    }
});
