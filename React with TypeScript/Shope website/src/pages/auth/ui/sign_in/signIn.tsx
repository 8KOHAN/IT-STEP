import { useEffect, useState } from "react";
import "./SignIn.css"
import { PageModes, type PageMode } from "../../model/PageModes";
import { SignInClick } from "../../lib/SignInClick";

type SignInProps = {
    setPageMode: React.Dispatch<React.SetStateAction<PageMode>>;
};

export default function SignIn({setPageMode}: SignInProps) {
    const [login, setLogin] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [isFormValid, setFormValid] = useState<boolean>(false)
    const signIn = SignInClick();

    useEffect(() => {
        setFormValid(
            login.length > 2 &&
            password.length > 2
        )
    }, [login, password])

    return (
        <div className="auth-form-content">

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

            <button className=
                {
                    `sign-button btn btn-${isFormValid
                        ? "primary"
                        : "secondary"}`
                }
                onClick={() => signIn(login, password)}>
                sign in
            </button>

            <button className="Forgotten-Password-Button" onClick={() => setPageMode(PageModes.forgotPassword)}>
                забыли пороль?
            </button>

        </div>
    )
}