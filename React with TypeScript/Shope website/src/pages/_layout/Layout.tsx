import { Link, Outlet } from "react-router-dom"
import "./ui/Layout.css"
import { useContext } from "react"
import AppContext from "../../Features/_context/AppContext"

export default function Layout() {
    const { cart } = useContext(AppContext);

    return <>
        <nav className="navbar navbar-expand-sm bg-body-tertiary">
            <div className="container-fluid">
                <a className="navbar-brand" href="#">Navbar</a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse d-flex justify-content-between" id="navbarSupportedContent">
                    <ul className="navbar-nav mb-2 mb-lg-0">
                        <li className="nav-item">
                            <Link to="/" className="nav-link">
                                <i className="bi bi-house"></i>
                            </Link>
                        </li>
                        <li className="nav-item cart-nav">
                            <Link to="/cart" className="nav-link">
                                <span>{cart.cartItems.length}</span>
                                <i className="bi bi-cart"></i>
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/Privacy" className="nav-link">
                                <i className="bi bi-lock"></i>
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/no-page" className="nav-link">
                                <i className="bi bi-sign-stop"></i>
                            </Link>
                        </li>
                    </ul>

                    <div className="d-flex direction-row">
                        <form className="d-flex" role="search">
                            <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search" />
                            <button className="btn btn-outline-success" type="button">Search</button>
                        </form>

                        <span style={{marginLeft: "10px"}}>
                            <Link to="/Auth" className="nav-link">
                                <i className="bi bi-person-square"></i>
                            </Link>
                        </span>

                    </div>
                </div>
            </div>
        </nav>

        <main>

            <Outlet />
        </main>

        <footer className="border-top bg-body-tertiary">
            <p>&copy; IT STEP, 2026</p>
            <Link to="/Privacy" className="link-primary Privacy-a nav-link">
                Privacy <i className="bi bi-lock"></i>
            </Link>
        </footer>
    </>
}