import { useContext } from "react"
import "./ui/Cart.css"
import AppContext from "../../features/_context/AppContext"
import Counter from "../../widgets/counter/Counter";
import type ICartItem from "../../entities/cart/model/ICartItem";
import StrikePrice, { StrikePriceRaw } from "../../widgets/strike_price/StrikePrice";

export default function Cart() {
    const { cart } = useContext(AppContext);

    return <div className="cart-wrapper row">
        <h1>Shopping Cart</h1>
        <div className="shopping-cart-root col col-8">
            {cart.cartItems.length == 0
                ? <p>Cart is empty</p>
                : cart.cartItems.map(ci => <CartItemView key={ci.product.id} ci={ci} />)}
        </div>

        <div className='order-wrapper col col-4'>
            <div className='mt-2 bg-light border p-0'>
                <h3 className='bg-body-tertiary border-bottom py-2 text-center'>Order summary</h3>
                <div className='d-flex justify-content-between mx-2 mb-2'>
                    <span>Subtotal</span>
                    {
                        cart.price < (cart.cartItems.reduce((acc, x) => acc + x.price, 0.0))
                            ? <StrikePriceRaw priceBefore={cart.cartItems.reduce((acc, x) => acc + x.price, 0.0)}
                                priceAfter={cart.price} />
                            : <b>₴{cart.cartItems.reduce((acc, x) => acc + x.price, 0.0).pad2()}</b>
                    }
                </div>
                <div className='d-flex justify-content-between mx-2 mb-3'>
                    <span>Delivery</span>
                    <b>₴{cart.delivery}</b>
                </div>
                <div className='d-flex justify-content-between px-2 mb-1 border-top py-2'>
                    <span>Total</span>
                    <b>₴{cart.price.pad2()}</b>
                </div>
            </div>
            <button className='btn btn-success w-100 mt-2'>Checkout</button>
        </div>
    </div >;
}

function CartItemView({ ci }: { ci: ICartItem }) {
    const { cart, setCart } = useContext(AppContext);

    const onQuantityChange = (quantity: number) => {
        let change = true;

        if (typeof (ci.product.stock) != "undefined") {
            if (quantity > ci.product.stock) {
                quantity -= 1;
                change = false
            }

        }

        if (quantity > 0) {
            ci.quantity = quantity
        } else {
            change = false;
            if (confirm("Delete?")) {
                setCart({
                    cartItems: cart.cartItems.filter(item => item.product.id !== ci.product.id),
                    price: 0
                }
                );
            }
        }

        if (change) {
            setCart({ ...cart });
        }

        console.log(quantity);

        return change;
    }

    return (
        <div className="shopping-cart-wrapper">
            <div>
                <div className="shopping-cart-img-wrapper">
                    <img src={ci.product.imageUrl}
                        alt={ci.product.name}
                        className="shopping-cart-img" />
                </div>
                <div className="shopping-cart-name">
                    {ci.product.name}
                </div>
                <div className="shopping-cart-price">
                    <StrikePrice productBrief={ci.product} />
                </div>
            </div>
            <div className="shopping-cart-counter-wrapper">
                <div className="shopping-cart-counter">
                    <Counter initialQuantity={ci.quantity}
                        onChange={onQuantityChange} />
                </div>
                <div className="shopping-cart-final-price">
                    ₴{
                        typeof ci.product.actionPrice == "undefined"
                            ? (ci.product.price * ci.quantity).pad2()
                            : (ci.product.actionPrice * ci.quantity).pad2()
                    }
                </div>
            </div>
        </div>
    )
}