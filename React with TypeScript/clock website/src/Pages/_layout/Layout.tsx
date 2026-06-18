import { Link, Outlet } from "react-router-dom"
import "./ui/Layout.css"

export default function Layout() {
    return <>
        <nav>
            <Link to="/">Home</Link> |{" "}
            <Link to="/group">Contact</Link>
        </nav>

        <Outlet/>

        <footer>
            &copy; IT STEP, 2026
        </footer>
    </>
}