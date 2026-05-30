function generateCalendar() {

    const month = Number(document.getElementById("month").value);
    const year = Number(document.getElementById("year").value);

    if (month < 1 || month > 12 || !year) {
        alert("Please enter the correct month and year");
        return;
    }

    const firstDay = new Date(year, month - 1, 1);

    let startDay = firstDay.getDay();

    startDay = (startDay + 6) % 7;

    const daysInMonth =
        new Date(year, month, 0).getDate();

    let html = `
    <table>
        <tr>
            <th>Пн</th>
            <th>Вт</th>
            <th>Ср</th>
            <th>Чт</th>
            <th>Пт</th>
            <th>Сб</th>
            <th>Нд</th>
        </tr>
        <tr>
    `;

    for (let i = 0; i < startDay; i++) {
        html += "<td></td>";
    }

    for (let day = 1; day <= daysInMonth; day++) {

        html += `<td>${day}</td>`;

        if ((day + startDay) % 7 === 0) {
            html += "</tr><tr>";
        }
    }

    const remaining =
        (7 - ((daysInMonth + startDay) % 7)) % 7;

    for (let i = 0; i < remaining; i++) {
        html += "<td></td>";
    }

    html += `
        </tr>
    </table>
    `;

    document.getElementById("calendar").innerHTML = html;
}
