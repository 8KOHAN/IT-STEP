import "./ui/Counter.css"
import { useState } from "react";
import RoundButton from "../../Features/round-button/RoundButton";

export default function Counter() {
    const [count, setCount] = useState<number>(0);

    return (
        <div className="Counter-Wrapper">
            <RoundButton label="-" action={() => setCount(count - 1)}/>
            <span className="count">{count}</span>
            <RoundButton label="+" action={() => setCount(count + 1)}/>
        </div>
    );
}