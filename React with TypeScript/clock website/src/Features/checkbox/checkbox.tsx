import "./ui/checkbox.css"

export default function Checkbox({ label } : { label: string }) {


    return (
        <div className="checkbox-wrapper">
            <label htmlFor="checkbox">
                <input type="checkbox" />

                {label}
            </label>
        </div>
    );
}