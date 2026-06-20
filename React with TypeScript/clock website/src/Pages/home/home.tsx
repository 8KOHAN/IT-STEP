import { useEffect, useState } from "react";
import Counter from "../../Widgets/counter/Counter";
import "./ui/home.css"
import type IGroup from "../../Entities/group/model/IGroup";
import GroupApi from "../../Entities/group/api/GroupApi";
import { Link } from "react-router-dom";

export default function Home() {
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

    const [groups, setGroups] = useState<Array<IGroup>>([]);

    useEffect(() => {
        GroupApi.allGroups().then(setGroups);
    }, []);

    return (
        <div className="home-wrapper">
            <h1>Shope</h1>

            <div className="cards row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4 row-cols-md-3 row-cols-xxl-5 g-4">
                {groups.map(g => <div className="col" key={g.id}>
                    <div className="card h-100">
                        <Link to={`/group/${g.slug}`}>
                            <img src={g.imageUrl} className="card-img-top" alt={g.name} />
                            <div className="card-body">
                                <h5 className="card-title">{g.name}</h5>
                                <p className="card-text">{g.description}</p>
                            </div>
                        </Link>
                    </div>
                </div>)}

            </div>


            {/* <Counter /> */}



            <div className="clock">
                <h2>{time.hour}:{time.min}</h2>
                <h3>{time.day}.{time.month}.{time.year}</h3>
            </div>

            <table>
                <thead>
                    <tr>
                        <th>time</th>
                        <th>Result</th>
                    </tr>
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
        </div >
    );
}