import { useContext } from "react";
import "./ui/Alert.css"
import AppContext from "../_context/AppContext";
import type IAlertData from "./model/IAlertData";

export default function Alert({ data }: { data: IAlertData }) {
    const { showAlert } = useContext(AppContext);

    return (
        <div className="alert-bg">
            <div className="alert-fg">
                {data.message}
                <button onClick={() => showAlert(null)}>Close</button>
            </div>
        </div>
    );
}