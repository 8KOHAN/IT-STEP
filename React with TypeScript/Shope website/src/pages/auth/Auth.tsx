import { useContext, useEffect, useState } from "react"
import "./ui/Auth.css"
import SignUp from "./ui/sign_up/SignUp"
import UserApi from "../../entities/user/api/UserApi";
import AppContext from "../../Features/_context/AppContext";
import Profile from "./ui/profile/Profile";

const PageModes = {
    signIn: 'signIn',
    signUp: 'signUp',
    profile: 'profile',
    forgotPassword: 'forgotPassword',
} as const;

type PageModes = (typeof PageModes)[keyof typeof PageModes]

export default function Auth() {
    const {user} = useContext(AppContext);

    const [pageMode, setPageMode] = useState<PageModes>(user ? PageModes.profile : PageModes.signIn);

    return (
        user ? <Profile /> : 
        <div className="auth-wrapper">
            <div className="auth-form">
                <h2>
                    {pageMode == PageModes.signIn ? "sign in" : "sign up"}
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
                {pageMode == PageModes.signIn ? <SignIn /> : <SignUp />}

            </div>


        </div>
    )
}

function SignIn() {
    const [login, setLogin] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [isFormValid, setFormValid] = useState<boolean>(false)
    const {setUser} = useContext(AppContext);

    useEffect(() => {
        setFormValid(
            login.length > 2 &&
            password.length > 2
        )
    }, [login, password])

    const signInClick = () => {
        UserApi.authenticate(login, password)
        .then(u => {

            window.localStorage.setItem("p42-token", u.token);
            setUser(u);
        }
        )
        .catch(err => {
            if(err === 401) {
                alert("у входе отказано. проверте данные")
            }
        });
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