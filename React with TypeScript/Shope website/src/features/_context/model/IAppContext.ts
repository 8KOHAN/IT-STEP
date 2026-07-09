import type ICart from "../../../entities/cart/model/ICart";
import type IUser from "../../../entities/user/model/IUser";

export default interface IAppContext {
    cart: ICart,
    setCart(cart: ICart): void,
    
    user?: IUser,
    setUser(user: IUser | undefined): void,
}