import { useState } from "react"
import "./SignUp.css"

interface IFormData {
    login: string,
    email: string,
    password: string,
    repeat: string,
    isAgree: boolean,
}

const initialFormData: IFormData = {
    login: "",
    email: "",
    password: "",
    repeat: "",
    isAgree: true,
}

function isEmailValid(email: string) {
    return /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/.test(email);
}

export default function SignUp() {
    const [formData, setFormData] =
        useState<IFormData>(initialFormData);

    const valids = {
        email: isEmailValid(formData.email),
    };

    const isFormValid: boolean = formData.login.length > 2 &&
        formData.password.length > 2 &&
        formData.email.length > 5 &&
        formData.password == formData.repeat &&
        formData.isAgree;

    const emailFeedback = "Адреса e-пошти повинна мистити символи '@' та '.'";

    return (
        <div className="reg-form-content">
            <div className="input-group mb-3">
                <span className="input-group-text" id="email-addon"><i className="bi bi-lock"></i></span>
                <input className={"form-control " + (formData.email.length === 0 ? "" : valids.email ? "is-valid" : "is-invalid")}
                    type='email' placeholder='E-mail'
                    value={formData.email}
                    onChange={e => setFormData({ ...formData, email: e.target.value })}
                    aria-label="User E-mail" aria-describedby="email-addon" />
                <div className="invalid-feedback">
                    {emailFeedback}
                </div>
            </div>
            <div className="input-group mb-3">
                <span className="input-group-text" id="login-addon"><i className="bi bi-lock"></i></span>
                <input className="form-control"
                    type='text' placeholder='Логін'
                    value={formData.login}
                    onChange={e => setFormData({ ...formData, login: e.target.value })}
                    aria-label="Username" aria-describedby="login-addon" />
            </div>

            <div className="input-group mb-3">
                <span className="input-group-text" id="password-addon"><i className="bi bi-key"></i></span>
                <input className="form-control"
                    type='password' placeholder='********'
                    value={formData.password}
                    onChange={e => setFormData({ ...formData, password: e.target.value })}
                    aria-label="Password" aria-describedby="password-addon" />
            </div>
            <div className="input-group mb-3">
                <span className="input-group-text" id="repeat-addon"><i className="bi bi-key-fill"></i></span>
                <input className="form-control"
                    type='password' placeholder='********'
                    value={formData.repeat}
                    onChange={e => setFormData({ ...formData, repeat: e.target.value })}
                    aria-label="Repeat Password" aria-describedby="repeat-addon" />
            </div>

            <div className="input-group mb-3">
                <div className="input-group-text">
                    <input className="form-check-input mt-0" type="checkbox"
                        onChange={e => setFormData({ ...formData, isAgree: e.target.checked })}
                        aria-label="Погодження з правилами сайту" />
                </div>
                <input type="text" className="form-control" aria-label="Погодження з правилами сайту"
                    value="Я погоджуюсь з правилами сайту" readOnly />
            </div>

            <button className=
                {
                    `sign-button btn btn-${isFormValid
                        ? "primary"
                        : "secondary"}`
                }>
                sign up
            </button>

        </div>
    )
}
