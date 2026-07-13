import { useContext } from "react";
import AppContext from "../../../features/_context/AppContext";
import UserApi from "../../../entities/user/api/UserApi";
import { rememberUser } from "../../../entities/user/lib/UserLib";

export function useSignIn() {
    const { setUser } = useContext(AppContext);

    return async (login: string, password: string) => {
        try {
            const user = await UserApi.authenticate(login, password);
            rememberUser(user);
            setUser(user);
            return true;
        } catch (err) {
            if (err === 401) {
                alert("Во входе отказано. Проверьте данные.");
            }
            return false;
        }
    };
}