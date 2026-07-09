import type ICartItem from "./ICartItem";

export default interface ICart {
    cartItems: ICartItem[],
    price: number,
    delivery?: number,
    discount?: string,
}