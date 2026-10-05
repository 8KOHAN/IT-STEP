import { createContext } from "react";
import type IAppContext from "./model/IAppContext";
import Locale_ukUA from "../../shared/l10n/Locale_uk-UA";

const AppContext = createContext<IAppContext>({
    cart: {
        cartItems: [],
        price: 0,
    },
    setCart(_) {
        throw "setCart: Not implemented";
    },
    user: undefined,
    setUser(_) {
        throw "setUser: Not implemented";
    },
    isLoading:false, 
    setLoading(_) {
        throw "setLoading: Not implemented";
    },
    showAlert(_) {
        throw "showAlert: Not implemented";
    },
    locale: Locale_ukUA,
    switchLocale(_) {
        throw "switchLocale: Not implemented";
    },
});

export default AppContext;

/*
Контекст (оточення, окіл) - спільне середовище, 
в середині якого створюється можливість доступу
до даних, зокрема, до кошику споживача
*/