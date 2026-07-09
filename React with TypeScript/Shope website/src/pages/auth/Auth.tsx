import { useEffect, useState } from "react"
import "./ui/Auth.css"
import Checkbox from "../../Features/checkbox/Checkbox";
import SignUp from "./ui/sign_up/SignUp"

export default function Auth() {
    const [pageMode, setPageMode] = useState<string>("singIn")

    return (
        <div className="auth-wrapper">
            <div className="auth-form">
                <h2>
                    {pageMode == "signIn" ? "sign in" : "sign up"}
                </h2>
                <div className='d-flex justify-content-between mx-2 gap-2'>
                    <button className=
                        {
                            `flex-1 btn btn-${pageMode === "signIn"
                                ? "primary"
                                : "secondary"}`
                        }
                        onClick={() => setPageMode("signIn")}>
                        sign in
                    </button>
                    <button className=
                        {
                            `flex-1 btn btn-${pageMode === "signUp"
                                ? "primary"
                                : "secondary"}`
                        }
                        onClick={() => setPageMode("signUp")}>
                        sign up
                    </button>
                </div>
                {pageMode == "signIn" ? <SignIn /> : <SignUp />}

            </div>


        </div>
    )
}

function SignIn() {
    const [login, setLogin] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [isFormValid, setFormValid] = useState<boolean>(false)

    useEffect(() => {
        setFormValid(
            login.length > 2 &&
            password.length > 2
        )
    }, [login, password])

    const signInClick = () => {

    };


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
            <div className="remember-me-wrapper">
                {Checkbox({ label: "remember me" })}
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

// function SignUp() {
//     return (
//         <>
//             SingUp
//         </>
//     )
// }