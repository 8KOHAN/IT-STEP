import "./ui/Counter.css"
import { useState } from "react";
import RoundButton from "../../Features/round-button/RoundButton";

export default function Counter({
    initialQuantity,
    onChange
}: {
    initialQuantity: number,
    onChange?: (quantity: number) => boolean
}) {
    const [count, setCount] = useState<number>(initialQuantity ?? 0);

    return (
        <div className="Counter-Wrapper">
            <RoundButton label="-" action={() => {
                if (onChange && onChange(count - 1)) {
                    setCount(count - 1);
                }
            }} />
            <span className="count">{count}</span>
            <RoundButton label="+" action={() => {
                if (onChange && onChange(count + 1)) {
                    setCount(count + 1);
                }
            }} />
        </div>
    );
}