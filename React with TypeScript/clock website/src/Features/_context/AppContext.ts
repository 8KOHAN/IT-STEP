import { createContext } from "react";
import type IAppContext from "./model/IAppContext";

const AppContext = createContext<IAppContext>({
    cart: [],
})

export default AppContext;