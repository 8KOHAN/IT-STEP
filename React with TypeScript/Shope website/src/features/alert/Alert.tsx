import { useContext } from "react";
import "./ui/Alert.css"
import AppContext from "../_context/AppContext";

export default function Alert() {
    const {showAlert} = useContext(AppContext);

    return (
        <div className="alert-bg">
            <div className="alert-fg">
                Alert
                <button onClick={() => showAlert(null)}>Close</button>
            </div>
        </div>
    );
}