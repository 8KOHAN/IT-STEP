document.getElementById("bookForm").addEventListener("submit", function (e) {
    e.preventDefault();

    let name = document.getElementById("name").value;
    let book = document.getElementById("book").value;
    let date = document.getElementById("date").value;
    let address = document.getElementById("address").value;

    document.getElementById("result").innerHTML =
        `${name}, Thank you for your order. ${book} will be delivered on ${date} to ${address}.`;
});
