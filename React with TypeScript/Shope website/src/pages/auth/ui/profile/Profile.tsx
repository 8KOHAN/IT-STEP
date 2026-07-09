import { useContext } from "react";
import "./Profile.css";
import AppContext from "../../../../Features/_context/AppContext";

export default function Profile() {
    const {user} = useContext(AppContext);

    return(
        <div className="profile-container">
            {user?.login}
        </div>
    )
}