const input = document.getElementById("nameInput");

input.addEventListener("input", () => {
    input.value = input.value.replace(/[0-9]/g, "");
});
