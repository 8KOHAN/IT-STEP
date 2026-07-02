import type ICart from "../model/ICart";

export default class CartApi {
    static calculateCart(cart:ICart): Promise<ICart> {
        return new Promise<ICart>((resolve, reject) => {
            setTimeout(() => {}, 500); 
        })
    }
}