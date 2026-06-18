import "./ui/Counter.css"
import { useState } from "react";
import RoundButton from "../../Features/round-button/RoundButton";
import Checkbox from "../../Features/checkbox/checkbox";

export default function Counter() {
    const [count, setCount] = useState<number>(0);

    return (
        <div className="Counter-Wrapper">
            <RoundButton label="-" action={() => setCount(count - 1)}/>
            <span className="count">{count}</span>
            <RoundButton label="+" action={() => setCount(count + 1)}/>

            <Checkbox label="не телефонувати"/>
        </div>
    );
}