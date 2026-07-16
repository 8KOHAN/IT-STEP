import { useContext } from "react";
import "./ui/Alert.css"
import AppContext from "../_context/AppContext";
import type IAlertData from "./model/IAlertData";

export default function Alert({ data }: { data: IAlertData }) {
    const { showAlert } = useContext(AppContext);

    const title = data.title ? data.title : "Модальное вікно";

    return (
        <div className="alert-bg" onClick={() => {
            if (data.isCancelable) {
                showAlert(null)
            }
        }}>
            <div className="alert-fg shadow-lg" onClick={e => e.stopPropagation()}>
                <div className="alert-header">
                    <h2>{title}</h2>
                </div>
                <div className="alert-message shadow-sm">
                    {data.message}
                </div>

                <div className="alert-buttons">
                    {data.buttons && data.buttons.length > 0
                        ? data.buttons.map(btn => <button key={btn.title}
                            onClick={() => {
                                if (btn.action) {
                                    btn.action();
                                }
                                showAlert(null)
                            }}>{btn.title}</button>)
                        : <button className="btn btn-danger"
                            onClick={() => showAlert(null)}
                        ><i className="bi bi-x-circle"> Close</i></button>
                    }


                </div>
            </div>
        </div>
    );
}