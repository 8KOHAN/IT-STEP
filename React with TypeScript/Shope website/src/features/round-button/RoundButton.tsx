import "./ui/RoundButton.css";

export default function RoundButton(
    { label, action } : 
    { label: string, action?: () => void }) 
    {
    return <button className="round-button" onClick={action}>{label}</button>
}