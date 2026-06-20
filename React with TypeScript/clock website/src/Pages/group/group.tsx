import { useParams } from "react-router-dom";
import "./ui/group.css";

export default function Group(){
    const {slug} = useParams();

    return(
        <div>
            <h1>{slug}</h1>
        </div>
    )
}