import type ICart from "../model/ICart";

export default class CartApi {
    static calculateCart(cart: ICart): Promise<ICart> {
        return new Promise<ICart>((resolve, reject) => {
            setTimeout(() => {
                let newCart = { ...cart };

                newCart.price = 0;
                for (let ci of newCart.cartItems) {
                    if (ci.quantity == 1) {
                        ci.price = ci.product.price
                    } else {
                        ci.price = ci.product.price * ci.quantity * 0.9;
                    }
                    newCart.price += ci.price;
                }
                if (newCart.price > 10_000){
                    newCart.price *= 0.95;
                    newCart.discount = "5%";
                } else{
                    newCart.discount = "5%";
                }

                newCart.delivery = 100;
                resolve(newCart)
            }, 500);
        })
    }
}