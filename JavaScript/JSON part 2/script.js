const jsonFile = document.getElementById("jsonFile");
const tableBody = document.querySelector("#resultTable tbody");

jsonFile.addEventListener("change", function (event) {
    const file = event.target.files[0];

    if (!file) return;

    const reader = new FileReader();

    reader.onload = function (e) {
        const jsonData = JSON.parse(e.target.result);

        tableBody.innerHTML = "";

        for (const key in jsonData) {
            const row = document.createElement("tr");

            const keyCell = document.createElement("td");
            keyCell.textContent = key;

            const valueCell = document.createElement("td");
            valueCell.textContent = jsonData[key];

            row.appendChild(keyCell);
            row.appendChild(valueCell);

            tableBody.appendChild(row);
        }
    };

    reader.readAsText(file);
});
