import { Link, useNavigate } from "react-router-dom";
import type IProductBrief from "../../../Entities/group/model/IProductBrief";
import { useContext } from "react";
import AppContext from "../../../Features/_context/AppContext";
import StrikePrice from "../../../Widgets/strike_price/StrikePrice";

export default function ProductCart({ productBrief }: { productBrief: IProductBrief }) {
    const { cart, setCart } = useContext(AppContext)
    const navigate = useNavigate();

    const addToCartClick = () => {
        setCart({
            cartItems: [...cart.cartItems, {
                product: productBrief,
                quantity: 1,
                price: productBrief.price
            }],
            price: 0,
        });
    };

    const isInCart = Boolean(cart.cartItems
        .find(ci =>
            ci.product.id == productBrief.id))


    return <div className="col" key={productBrief.id}>
        <div className="card h-100">
            <Link to={`/group/${productBrief.slug}`}>
                <img src={productBrief.imageUrl} className="card-img-top" alt={productBrief.name} />
            </Link>
            <div className="card-body">
                <h5 className="card-title">{productBrief.name}</h5>
                <p className="card-text">{productBrief.description}</p>
            </div>
            <div className="card-footer d-flex justify-content-between align-items-center">
                <StrikePrice productBrief={productBrief}/>
                {isInCart
                    ? <button className="btn btn-success" onClick={() => navigate('/cart')}>
                        <i className="bi bi-cart-check"></i>
                    </button>
                    : <button className="btn btn-outline-success" onClick={addToCartClick}>
                        <i className="bi bi-cart"></i>
                    </button>
                }

            </div>
        </div>
    </div>
}