import '../../shared/extensions/NumberExtensions';
import { useEffect, useState } from "react";
import './App.css';
import AppContext from '../../features/_context/AppContext';
import type ICart from "../../entities/cart/model/ICart";
import CartApi from "../../entities/cart/api/CartApi";
import type IUser from '../../entities/user/model/IUser';
import { getRememberedUser, } from '../../entities/user/lib/UserLib';
import Router from './Router';
import Alert from '../../features/alert/Alert';
import type IAlertData from '../../features/alert/model/IAlertData';
import Locale_ukUA from '../../shared/l10n/Locale_uk-UA';

export default function App() {
    const [cart, setCart] = useState<ICart>({cartItems: [], price: 0});
    const [user, setUser] = useState<IUser|undefined>();
    const [isLoading, setLoading] = useState<boolean>(false);
    const [alertData, setAlertData] = useState<IAlertData|null>(null);
    const [locale, setLocale] = useState(Locale_ukUA);

    const updateCart = (cart:ICart):void => {
        // перед зміною стану здійснюємо запит на обчислення знижок по кошику
        CartApi.calculateCart(cart)
        .then(setCart);
    }

    useEffect(() => {
        // дії при (пере)запуску, у т.ч. оновленні сторінки
        // перевіряємо чи є в локальному сховищі дані про користувача (токен)
        setUser( getRememberedUser() );
    }, []);

    return (
    <AppContext.Provider value={{
            cart, setCart: updateCart, 
            user, setUser, 
            isLoading, setLoading,
            showAlert: setAlertData,
            locale: locale,
            switchLocale: setLocale,
        }}>
        <Router />
        {alertData && <Alert data={alertData} />}
    </AppContext.Provider>
    );
}
/*
Д.З. Розробити компонент (feature) на базі checkbox
(switch).
Додати до компонента Counter новий компонент
з текстом "не телефонувати"
*/