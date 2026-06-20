import { BrowserRouter, Route, Routes } from "react-router-dom"
import Home from "../../Pages/home/home"
import "./App.css"
import Group from "../../Pages/group/group";
import Layout from "../../Pages/_layout/Layout";
import NotFound from "../../Pages/not_found/NotFound";
import Privacy from "../../Pages/privacy/Privacy";

export default function App() {
    return (
        <BrowserRouter>

            <Routes>
                <Route path="/" element={<Layout />} >
                    <Route index element={<Home />} />
                    <Route path="group" element={<Group />} />

                    <Route path="Privacy" element={<Privacy />} />
                    <Route path="*" element={<NotFound />} />
                </Route>
            </Routes>
        </BrowserRouter>
    );
    <Home />

}
