import { useContext } from "react";
import "./ui/Alert.css"
import AppContext from "../_context/AppContext";
import type IAlertData from "./model/IAlertData";

export default function Alert({ data }: { data: IAlertData }) {
    const { showAlert } = useContext(AppContext);

    const title = data.title ? data.title : "Модальное вікно";

    return (
        <div className="alert-bg">
            <div className="alert-fg shadow-lg">
                <div className="alert-header">
                    <h2>{title}</h2>
                </div>
                <div className="alert-message shadow-sm">
                    {data.message}
                </div>
                <button className="btn btn-danger"
                    onClick={() => showAlert(null)}
                ><i className="bi bi-x-circle"> Close</i></button>
            </div>
        </div>
    );
}