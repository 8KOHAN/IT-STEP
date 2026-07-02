import "./ui/Counter.css"
import { useState } from "react";
import RoundButton from "../../Features/round-button/RoundButton";

export default function Counter({
    initialQuantity,
    onChange
}: {
    initialQuantity: number,
    onChange?: (quantity: number) => void
}) {
    const [count, setCount] = useState<number>(initialQuantity ?? 0);

    return (
        <div className="Counter-Wrapper">
            <RoundButton label="-" action={() => {
                setCount(count - 1);
                if (onChange) onChange(count - 1)
            }} />
            <span className="count">{count}</span>
            <RoundButton label="+" action={() => {
                setCount(count + 1);
                if (onChange) onChange(count + 1)
            }} />
        </div>
    );
}