import { useContext, useEffect } from 'react';
import { Link, Outlet } from 'react-router-dom';
import './ui/Layout.css';
import AppContext from '../../features/_context/AppContext';
import { clearRememberedUser } from '../../entities/user/lib/UserLib';
import Locale_enUS from '../../shared/l10n/Locale_en-US';
import Locale_ukUA from '../../shared/l10n/Locale_uk-UA';

export default function Layout() {
    // вилучаємо дані з контексту застосунку (глобального стану)
    const {cart, user, setUser, isLoading, showAlert, locale, switchLocale} = useContext(AppContext);

    const logoutClick = () => {
        clearRememberedUser();
        setUser(undefined);
    }

    useEffect(() => {
        document.body.style.overflow = isLoading ? "hidden" : "auto";
    }, [isLoading]);

    return <>    
    <nav className="navbar navbar-expand-sm bg-body-tertiary border-bottom">
        <div className="container-fluid">
            <a className="navbar-brand" href="#">Navbar</a>
            <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse d-flex justify-content-between" id="navbarSupportedContent">
                <ul className="navbar-nav mb-2 mb-lg-0">
                    <li className="nav-item">
                        <Link to="/" className="nav-link"><i className="bi bi-house"></i></Link>
                    </li>
                    <li className="nav-item">
                        <Link to="/cart" className="nav-link cart-nav">
                            <span>{cart.cartItems.length}</span>
                            <i className="bi bi-cart"></i>
                        </Link>
                    </li>                
                    <li className="nav-item">
                        <Link to="/no-page" className="nav-link"><i className="bi bi-sign-stop"></i></Link>
                    </li>              
                    <li className="nav-item">
                        <span onClick={() => showAlert({message: "Hello"})} className="nav-link">
                            <i className="bi bi-key"></i>
                        </span>
                    </li>
                    <li className="nav-item">
                        <span onClick={() => showAlert({
                            message: "Hello",
                            buttons: [{title: "Ok"}],
                            isCancelable: true,
                        })} className="nav-link">
                            <i className="bi bi-key"></i>
                        </span>
                    </li>
                    <li className="nav-item">
                        <span onClick={() => showAlert({
                            message: "Hello",
                            buttons: [
                                {title: "Yes", action: () => console.log("Yes")},
                                {title: "No", action: () => console.log("No")},
                            ]
                        })} className="nav-link">
                            <i className="bi bi-key"></i>
                        </span>
                    </li>                       
                </ul>
                <form className="d-flex" role="search">
                    <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
                    <button className="btn btn-outline-success" type="button">Search</button>
                </form>
                <div className="d-flex align-items-center" >
                    <span className="nav-item">
                        <Link to="/auth" className="nav-link" title={user ? "Кабінет користувача" : "Вхід до сайту"}>
                            <i className="bi bi-person-square fs-5"></i>
                        </Link>
                    </span>
                    {user && <span className="nav-item ms-2" role='button' onClick={logoutClick}>
                        <i className="bi bi-box-arrow-right fs-4"></i>
                    </span>}
                </div>
            </div>
        </div>
    </nav>

    <main>
        <Outlet />
        {isLoading && <div className='preloader'><img src="/img/loading.gif" alt="loading" /></div>}
    </main>    
    
    <footer className='border-top bg-body-tertiary'>
        &copy; {locale.layoutFooterCopyright}
        <button onClick={() => switchLocale(Locale_enUS)}>en-US</button>
        <button onClick={() => switchLocale(Locale_ukUA)}>uk-UA</button>
    </footer>
    </>;
}