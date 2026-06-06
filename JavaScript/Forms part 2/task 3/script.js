document.getElementById("userForm").addEventListener("submit", function (e) {
    e.preventDefault();

    let name = document.getElementById("name").value;
    let age = document.getElementById("age").value;
    let city = document.getElementById("city").value;
    let gender = document.getElementById("gender").value;

    document.getElementById("result").innerHTML =
        `
        Name: ${name}<br>
        Age: ${age}<br>
        City: ${city}<br>
        Gender: ${gender}
        `;
});
