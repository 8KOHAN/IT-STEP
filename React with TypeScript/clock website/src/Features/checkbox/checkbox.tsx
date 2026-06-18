import "./ui/checkbox.css"

export default function checkbox({ label } : { label: string }) {


    return (
        <div className="checkbox-wrapper">
            <label htmlFor="checkbox">
                <input type="checkbox" />

                {label}
            </label>
        </div>
    );
}