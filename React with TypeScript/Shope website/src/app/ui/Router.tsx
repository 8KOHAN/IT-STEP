import { BrowserRouter, Route, Routes } from "react-router-dom";
import Privacy from "../../pages/privacy/Privacy";
import NotFound from "../../pages/not_found/NotFound";
import Group from "../../pages/group/group";
import Auth from "../../pages/auth/Auth";
import Cart from "../../pages/cart/Cart";
import Home from "../../pages/home/home";
import Layout from "../../pages/_layout/Layout";

export default function Router() {
    return (
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
    )
}