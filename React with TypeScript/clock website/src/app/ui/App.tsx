import { BrowserRouter, Route, Routes } from "react-router-dom"
import Home from "../../Pages/home/home"
import "./App.css"
import Group from "../../Pages/group/group";
import Layout from "../../Pages/_layout/Layout";
import NotFound from "../../Pages/not_found/NotFound";
import Privacy from "../../Pages/privacy/Privacy";
import AppContext from "../../Features/_context/AppContext";
import { useState } from "react";
import Cart from "../../Pages/cart/Cart";
import type ICartItem from "../../Entities/cart/model/ICartItem";
import type ICart from "../../Entities/cart/model/ICart";

export default function App() {
    const [cart, setCart] = useState<ICart>({cartItems: [], price: 0})
    const updateCart = (cart: ICart): void => {
        

        setCart(cart);
    };

    return (
        <AppContext.Provider value={{cart, setCart: updateCart}}>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Layout />} >
                        <Route index element={<Home />} />
                        <Route path="cart" element={<Cart />} />
                        <Route path="group/:slug" element={<Group />} />


                        <Route path="Privacy" element={<Privacy />} />
                        <Route path="*" element={<NotFound />} />
                    </Route>
                </Routes>
            </BrowserRouter>
        </AppContext.Provider>
    );

}
