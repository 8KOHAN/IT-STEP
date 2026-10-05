import { useContext, useEffect, useState } from "react";
import "./ui/home.css"
import type IGroup from "../../entities/group/model/IGroup";
import GroupApi from "../../entities/group/api/GroupApi";
import { Link } from "react-router-dom";
import AppContext from "../../features/_context/AppContext";
import type IPagination from "../../entities/_api_base/model/IPagination";

const preload_grp: Array<IGroup> = Array.from({ length: 20 }, (_, i) => {
    return {
        id: i + 1 + "",
        name: "Loading...",
        description: "Loading...",
        slug: "",
        imageUrl: "/img/чорный_фон.png"
    }
});

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

    const [groups, setGroups] = useState<Array<IGroup>>(preload_grp);
    const { setLoading, locale } = useContext(AppContext);
    const [pagination, setPagination] = useState<IPagination | undefined>();
    const [currentPage, setCurrentPage] = useState(1);

    useEffect(() => {
        setLoading(true);

        GroupApi.allGroups(currentPage)
            .then(grp => {
                setGroups(grp.data);
                setPagination(grp.meta.pagination);
            })
            .finally(() => {
                setLoading(false);
            });
    }, [currentPage]);

    const prevClick = () => {
        if (currentPage > 1) {
            setCurrentPage(currentPage - 1);
        }
    };

    const nextClick = () => {
        if (pagination && currentPage < pagination.totalPages) {
            setCurrentPage(currentPage + 1);
        }
    };

    const gotoClick = (page: number) => {
        if (page >= 1 && pagination && page <= pagination.totalPages) {
            setCurrentPage(page);
        }
    };

    const getPageNumbers = () => {
        if (!pagination) {
            return [];
        }

        const totalPages = pagination.totalPages;

        if (totalPages <= 3) {
            return Array.from(
                { length: totalPages },
                (_, i) => i + 1
            );
        }

        if (currentPage <= 2) {
            return [1, 2, 3];
        }

        if (currentPage >= totalPages - 1) {
            return [totalPages - 2, totalPages - 1, totalPages];
        }

        return [
            currentPage - 1,
            currentPage,
            currentPage + 1
        ];
    };

    return (
        <div className="home-wrapper">
            <h1>{locale.homePageTitle}</h1>

            <div className="cards row row-cols-1 row-cols-sm-2 row-cols-lg-4 row-cols-md-3 row-cols-xxl-5 g-4">
                {groups.map(g =>
                    <div className="col" key={g.id}>
                        <div className="card h-100">
                            <Link to={`/group/${g.slug}`}>
                                <img
                                    src={g.imageUrl}
                                    className="card-img-top"
                                    alt={g.name}
                                />
                                <div className="card-body">
                                    <h5 className="card-title">{g.name}</h5>
                                    <p className="card-text">{g.description}</p>
                                </div>
                            </Link>
                        </div>
                    </div>
                )}
            </div>

            {pagination && pagination.totalPages > 0 &&
                <nav className="my-4" aria-label="Page navigation">
                    <ul className="pagination">

                        <li
                            className={
                                "page-item" +
                                (currentPage === 1 ? " disabled" : "")
                            }
                        >
                            <button
                                className="page-link"
                                aria-label="Previous"
                                onClick={prevClick}
                                disabled={currentPage === 1}
                            >
                                &laquo;
                            </button>
                        </li>

                        {getPageNumbers().map(page =>
                            <li
                                key={page}
                                className={
                                    "page-item" +
                                    (page === currentPage ? " active" : "")
                                }
                            >
                                <button
                                    className="page-link"
                                    onClick={() => gotoClick(page)}
                                    disabled={page === currentPage}
                                >
                                    {page}
                                </button>
                            </li>
                        )}

                        <li
                            className={
                                "page-item" +
                                (
                                    currentPage === pagination.totalPages
                                        ? " disabled"
                                        : ""
                                )
                            }
                        >
                            <button
                                className="page-link"
                                aria-label="Next"
                                onClick={nextClick}
                                disabled={
                                    currentPage === pagination.totalPages
                                }
                            >
                                &raquo;
                            </button>
                        </li>

                    </ul>
                </nav>
            }

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
        </div>
    );
}