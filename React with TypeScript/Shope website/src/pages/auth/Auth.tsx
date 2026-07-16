import { useContext, useEffect, useState } from "react"
import "./ui/Auth.css"
import SignUp from "./ui/sign_up/SignUp"
import AppContext from "../../features/_context/AppContext";
import Profile from "./ui/profile/Profile";
import SignIn from "./ui/sign_in/SignIn";
import ForgotPassword from "./ui/forgot_password/ForgotPassword";
import { PageModes, type PageMode } from "./model/PageModes";

export default function Auth() {
    const { user } = useContext(AppContext)

    const { setLoading } = useContext(AppContext);

    useEffect(() => {
        setLoading(true);

        const timer = setTimeout(() => {
            setLoading(false);
        }, 1500);

        return () => clearTimeout(timer);
    }, []);

    const [pageMode, setPageMode] = useState<PageMode>(user ? PageModes.profile : PageModes.signIn);

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
                    {pageMode == PageModes.signIn ? <SignIn setPageMode={setPageMode} /> : pageMode == PageModes.signUp ? <SignUp /> : <ForgotPassword />}

                </div>


            </div>
    )
}
