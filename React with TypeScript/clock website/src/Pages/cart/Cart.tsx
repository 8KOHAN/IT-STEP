import { useContext } from "react"
import "./ui/Cart.css"
import AppContext from "../../Features/_context/AppContext"
import Counter from "../../Widgets/counter/Counter";
import type ICartItem from "../../Entities/cart/model/ICartItem";
import StrikePrice from "../../Widgets/strike_price/StrikePrice";

export default function Cart() {
    const { cart } = useContext(AppContext);

    return <div className="row">
        <div className="col col-8">
            <h1>Shopping Cart</h1>
            {cart.length == 0
                ? <p>Cart is empty</p>
                : cart.map(ci => <CartItemView key={ci.product.id} ci={ci} />)}
        </div>

        <div className="col col-4 bg-light">
            <h2>Order summary</h2>
        </div>
    </div>
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
                setCart(
                    cart.filter(item => item.product.id !== ci.product.id)
                );
            }
        }

        if (change) {
            setCart([...cart]);
        }

        console.log(quantity);

        return change;
    }

    return (
        <div className="shopping-cart-wrapper">
            <div>
                <img src={ci.product.imageUrl}
                    alt={ci.product.name}
                    className="shopping-cart-img" />
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
                    {
                        typeof ci.product.actionPrice == "undefined"
                            ? (ci.product.price * ci.quantity).toFixed(2)
                            : (ci.product.actionPrice * ci.quantity).toFixed(2)
                    }
                </div>
            </div>
        </div>
    )
}