let bookings = [];

function bookTickets() {

    let route = document.getElementById("route").value;
    let date = document.getElementById("date").value;
    let seats = [];

    document.querySelectorAll('.seats input:checked')
        .forEach(item => seats.push(item.value));

    bookings.push({
        route,
        date,
        seats
    });

    alert("Tickets booked");
}

function showBookings() {

    let output = "<h3>Booked tickets</h3>";

    bookings.forEach(item => {
        output += `
        <p>
            Route: ${item.route}<br>
            Date: ${item.date}<br>
            Seats: ${item.seats.join(", ")}
        </p><hr>`;
    });

    document.getElementById("history").innerHTML = output;
}
