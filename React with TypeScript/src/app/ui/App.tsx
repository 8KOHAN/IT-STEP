import "./App.css"

export default function App() {
    const months = [
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"
    ];

    const weekDays = [
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday",
        "Sunday"
    ];

    const data: Date = new Date();
    const format = (n: number) => String(n).padStart(2, "0");
    const time = {
        year: data.getFullYear(),
        month: format(data.getMonth() + 1),
        monthName: months[data.getMonth()],
        nameWeekDay: weekDays[(data.getDay() + 6) % 7],
        day: format(data.getDate()),
        hour: format(data.getHours()),
        min: format(data.getMinutes()),
        sec: format(data.getSeconds())
    }

    return (
        <div>
            <div className="clock">
                <h2>{time.hour}:{time.min}</h2>
                <h3>{time.day}.{time.month}.{time.year}</h3>
            </div>


            <table>
                <thead>
                    <th>time</th>
                    <th>Result</th>
                </thead>
                <tbody>
                    <tr>
                        <td>Year:</td>
                        <td>{time.year}</td>
                    </tr>
                    <tr>
                        <td>Month:</td>
                        <td>{time.monthName}</td>
                    </tr>
                    <tr>
                        <td>Day:</td>
                        <td>{time.day}</td>
                    </tr>
                    <tr>
                        <td>Day week:</td>
                        <td>{time.nameWeekDay}</td>
                    </tr>
                    <tr>
                        <td>Hour:</td>
                        <td>{time.hour}</td>
                    </tr>
                    <tr>
                        <td>Minute:</td>
                        <td>{time.min}</td>
                    </tr>
                    <tr>
                        <td>Seconds:</td>
                        <td>{time.sec}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    );
}
