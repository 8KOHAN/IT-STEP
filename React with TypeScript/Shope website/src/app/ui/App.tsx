import "../../shared/extensions/NumberExtensions"
import "./App.css"
import AppContext from "../../features/_context/AppContext";
import { useEffect, useState } from "react";
import type ICart from "../../entities/cart/model/ICart";
import CartApi from "../../entities/cart/api/CartApi";
import type IUser from "../../entities/user/model/IUser";
import { getRememberUser } from "../../entities/user/lib/UserLib";
import Router from "./Router";
import Alert from "../../features/alert/Alert";
import type IAlertData from "../../features/alert/model/IAlertData";

export default function App() {
    const [cart, setCart] = useState<ICart>({ cartItems: [], price: 0 })
    const [user, setUser] = useState<IUser | undefined>();
    const [isLoading, setLoading] = useState<boolean>(false);
    const [alertData, setAlertData] = useState<IAlertData | null>(null)
    const showAlert = setAlertData;

    const updateCart = (cart: ICart): void => {
        CartApi.calculateCart(cart)
            .then(setCart)
    };

    useEffect(() => {
        setUser(getRememberUser())
    }, [])

    return (
        <AppContext.Provider value={{
            cart, setCart: updateCart,
            user, setUser,
            isLoading, setLoading,
            showAlert
        }}>
            <Router />
            {alertData && <Alert />}
        </AppContext.Provider>
    );

}
