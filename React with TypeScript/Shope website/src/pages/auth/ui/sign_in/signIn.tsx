import { useContext, useEffect, useState } from "react";
import "./signIn.css"
import AppContext from "../../../../features/_context/AppContext";
import { rememberUser } from "../../../../entities/user/lib/UserLib";
import UserApi from "../../../../entities/user/api/UserApi";

export default function SignIn() {
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
            rememberUser(u);
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