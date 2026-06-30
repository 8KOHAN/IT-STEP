import { Link } from "react-router-dom";
import type IProductBrief from "../../../Entities/group/model/IProductBrief";
import { useContext } from "react";
import AppContext from "../../../Features/_context/AppContext";

export default function ProductCart({ productBrief }: { productBrief: IProductBrief }) {
    const { cart, setCart } = useContext(AppContext)

    const addToCartClick = () => {
        setCart([...cart, {
            product: productBrief,
            quantity: 1,
        }]);
    };

    const isInCart = Boolean(cart
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
                <div>
                    {
                        typeof productBrief.actionPrice == "undefined"
                            ? <div><b>₴ {productBrief.price.toFixed(2)}</b></div>
                            : <div>
                                <div>
                                    <div className="strike-price">₴ {productBrief.price.toFixed(2)}</div>
                                </div>
                                <div><b><b>₴ {productBrief.actionPrice.toFixed(2)}</b></b></div>
                            </div>
                    }
                </div>
                <button className="btn btn-outline-success" onClick={addToCartClick}>
                    <i className="bi bi-cart"></i>
                </button>
            </div>
        </div>
    </div>
}