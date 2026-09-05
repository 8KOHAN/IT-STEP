import { useState } from "react"
import "./SignUp.css"
import type IUserSignupData from "../../../../entities/user/model/IUserSignupData";
import UserApi from "../../../../entities/user/api/UserApi";


const initialFormData: IUserSignupData = {
    login: "",
    email: "",
    fullName: "",
    phone: "",
    password: "",
    repeat: "",
    isAgree: false,
}

function isEmailValid(email: string) {
    return /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/.test(email);
}

export default function SignUp() {
    const [formData, setFormData] =
        useState<IUserSignupData>(initialFormData);

    const valids = {
        login: /^[a-zA-Z0-9_]{3,20}$/.test(formData.login),
        email: isEmailValid(formData.email),
        password:
            /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*#?&]{6,}$/.test(formData.password),
        repeat:
            formData.password === formData.repeat,
        isAgree: formData.isAgree,
    };

    const isFormValid =
        valids.login &&
        valids.email &&
        valids.password &&
        valids.repeat &&
        valids.isAgree;

    const emailFeedback = "Адреса e-пошти повинна мистити символи '@' та '.'";

    const signUpClick = () => {
        UserApi.signUp(formData)
        .then(() => {console.log("Sign Up OK [200]")})
        .catch(() => {console.log("sign Up Fail")})
    }

    return (
        

        <div className="reg-form-content">
            <div className="input-group mb-3">
                <span className="input-group-text" id="login-addon"><i className="bi bi-lock"></i></span>
                <input className={
                    "form-control " +
                    (formData.login.length === 0
                        ? ""
                        : valids.login
                            ? "is-valid"
                            : "is-invalid")
                }
                    type='text' placeholder="ім'я"
                    value={formData.fullName}
                    onChange={e => setFormData({ ...formData, fullName: e.target.value })}
                    aria-label="Username" aria-describedby="login-addon" />
            </div>

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
                <input className={
                    "form-control " +
                    (formData.login.length === 0
                        ? ""
                        : valids.login
                            ? "is-valid"
                            : "is-invalid")
                }
                    type='text' placeholder='Логін'
                    value={formData.login}
                    onChange={e => setFormData({ ...formData, login: e.target.value })}
                    aria-label="Username" aria-describedby="login-addon" />
            </div>

            <div className="input-group mb-3">
                <span className="input-group-text" id="phone-addon"><i className="bi bi-lock"></i></span>
                <input className={
                    "form-control " +
                    (formData.login.length === 0
                        ? ""
                        : valids.login
                            ? "is-valid"
                            : "is-invalid")
                }
                    type='text' placeholder="phone"
                    value={formData.phone}
                    onChange={e => setFormData({ ...formData, phone: e.target.value })}
                    aria-label="Username" aria-describedby="phone-addon" />
            </div>

            <div className="input-group mb-3">
                <span className="input-group-text" id="password-addon"><i className="bi bi-key"></i></span>
                <input className={
                    "form-control " +
                    (formData.password.length === 0
                        ? ""
                        : valids.password
                            ? "is-valid"
                            : "is-invalid")
                }
                    type='password' placeholder='********'
                    value={formData.password}
                    onChange={e => setFormData({ ...formData, password: e.target.value })}
                    aria-label="Password" aria-describedby="password-addon" />
            </div>
            <div className="input-group mb-3">
                <span className="input-group-text" id="repeat-addon"><i className="bi bi-key-fill"></i></span>
                <input className={
                    "form-control " +
                    (formData.repeat.length === 0
                        ? ""
                        : valids.repeat
                            ? "is-valid"
                            : "is-invalid")
                }
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
                }
                onClick={isFormValid ? signUpClick : undefined}
                >
                sign up
            </button>

        </div>
    )
}
