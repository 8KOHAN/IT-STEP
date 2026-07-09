import "../../shared/extensions/NumberExtensions"
import { BrowserRouter, Route, Routes } from "react-router-dom"
import Home from "../../pages/home/home"
import "./App.css"
import Group from "../../pages/group/group";
import Layout from "../../pages/_layout/Layout";
import NotFound from "../../pages/not_found/NotFound";
import Privacy from "../../pages/privacy/Privacy";
import AppContext from "../../Features/_context/AppContext";
import { useEffect, useState } from "react";
import Cart from "../../pages/cart/Cart";
import type ICart from "../../entities/cart/model/ICart";
import CartApi from "../../entities/cart/api/CartApi";
import Auth from "../../pages/auth/Auth";
import type IUser from "../../entities/user/model/IUser";
import { getRememberUser} from "../../entities/user/lib/UserLib";

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
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Layout />} >
                        <Route index element={<Home />} />
                        <Route path="cart" element={<Cart />} />
                        <Route path="group/:slug" element={<Group />} />
                        <Route path="Auth" element={<Auth />} />


                        <Route path="Privacy" element={<Privacy />} />
                        <Route path="*" element={<NotFound />} />
                    </Route>
                </Routes>
            </BrowserRouter>
        </AppContext.Provider>
    );

}
