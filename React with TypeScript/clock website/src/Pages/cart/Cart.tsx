import { useContext } from "react"
import "./ui/Cart.css"
import AppContext from "../../Features/_context/AppContext"

export default function Cart() {
    const { cart } = useContext(AppContext);

    return <div className="row">
        <div className="col col-8">
            <h1>Shopping Cart</h1>
            {cart.length == 0
                ? <p>Cart is empty</p>
                : cart.map(ci => <div key={ci.product.id} className="shopping-cart-wrapper row mb-3">
                    <div className="col col-2">
                        <img src={ci.product.imageUrl}
                            alt={ci.product.name}
                            className="shopping-cart-img w-100" />
                    </div>
                    <div className="col col-7">
                        {ci.product.name}
                    </div>
                    <div className="col col-1">
                        {ci.product.price}
                    </div>
                    <div className="col col-2">
                        {ci.quantity}
                    </div>
                    <div className="col col-1">
                        {ci.product.price * ci.quantity}
                    </div>

                </div>)}
        </div>

        <div className="col col-4 bg-light">
            <h2>Order summary</h2>
        </div>
    </div>
}