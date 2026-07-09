import { createContext } from "react";
import type IAppContext from "./model/IAppContext";

const AppContext = createContext<IAppContext>({
    cart: {
        cartItems: [],
        price: 0,
    },
    setCart(_) {
        throw "setCart: Not implemented";
    }
});

export default AppContext;