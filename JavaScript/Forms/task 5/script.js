let attendanceList = [];

function saveAttendance() {
    let group = document.getElementById("group").value;
    let lesson = document.getElementById("lesson").value;
    let topic = document.getElementById("topic").value;

    let students = [];

    document.querySelectorAll('input[type="checkbox"]:checked')
        .forEach(el => students.push(el.value));

    attendanceList.push({
        group,
        lesson,
        topic,
        students
    });

    alert("Data saved");
}

function showAttendance() {
    let output = "<h3>History</h3>";

    attendanceList.forEach(item => {
        output += `
        <p>
            Group: ${item.group}<br>
            Pair: ${item.lesson}<br>
            Topic: ${item.topic}<br>
            Attendees: ${item.students.join(", ")}
        </p><hr>`;
    });

    document.getElementById("history").innerHTML = output;
}
