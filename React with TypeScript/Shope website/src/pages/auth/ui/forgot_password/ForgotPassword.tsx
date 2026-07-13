import { useEffect, useState } from "react";
import "./ForgotPassword.css"
import { getRememberUser } from "../../../../entities/user/lib/UserLib";

export default function ForgotPassword() {
    const [login, setLogin] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [repeat, setRepeat] = useState<string>("");
    const [isFormValid, setFormValid] = useState<boolean>(false)

    useEffect(() => {
            setFormValid(
                login === getRememberUser()?.login &&
                password.length > 2
            )
        }, [login, password])

    return (
        <div className="forgot-form-content">
            <div className="input-group mb-3">
                <span className="input-group-text" id="login-addon"><i className="bi bi-lock"></i></span>
                <input className="form-control"
                    type='text' placeholder='Логін'
                    value={login}
                    onChange={e => setLogin(e.target.value)}
                    aria-label="Username" aria-describedby="login-addon" />
            </div>

            <div className="input-group mb-3">
                <span className="input-group-text" id="password-addon"><i className="bi bi-key"></i></span>
                <input className="form-control"
                    type='password' placeholder='********'
                    value={password}
                    onChange={e => setPassword(e.target.value)}
                    aria-label="Password" aria-describedby="password-addon" />
            </div>
            <div className="input-group mb-3">
                <span className="input-group-text" id="repeat-addon"><i className="bi bi-key-fill"></i></span>
                <input className="form-control"
                    type='password' placeholder='********'
                    value={repeat}
                    onChange={e => setRepeat(e.target.value)}
                    aria-label="Repeat Password" aria-describedby="repeat-addon" />
            </div>

            <button className=
                {
                    `sign-button btn btn-${isFormValid
                        ? "primary"
                        : "secondary"}`
                }
                onClick={isFormValid ? signInClick : undefined}>
                sign in
            </button>
        </div>
    )
}