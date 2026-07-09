import type ICart from "../../../Entities/cart/model/ICart";
import type ICartItem from "../../../Entities/cart/model/ICartItem";

export default interface IAppContext {
    cart: ICart,
    setCart(cart: ICart): void,
}