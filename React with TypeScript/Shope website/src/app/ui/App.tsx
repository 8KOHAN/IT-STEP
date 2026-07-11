import "../../shared/extensions/NumberExtensions"
import "./App.css"
import AppContext from "../../features/_context/AppContext";
import { useEffect, useState } from "react";
import type ICart from "../../entities/cart/model/ICart";
import CartApi from "../../entities/cart/api/CartApi";
import type IUser from "../../entities/user/model/IUser";
import { getRememberUser} from "../../entities/user/lib/UserLib";
import Router from "./Router";

export default function App() {
    const [cart, setCart] = useState<ICart>({cartItems: [], price: 0})
    const [user, setUser] = useState<IUser|undefined>();
    const updateCart = (cart: ICart): void => {
        CartApi.calculateCart(cart)
        .then(setCart)
    };

    useEffect(() => {
        setUser(getRememberUser())
    }, [])

    return (
        <AppContext.Provider value={{cart, setCart: updateCart, user, setUser}}>
            <Router/>
        </AppContext.Provider>
    );

}
