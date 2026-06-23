import { Link } from "react-router-dom";
import type IProductBrief from "../../../Entities/group/model/IProductBrief";

export default function ProductCart({ productBrief }: { productBrief: IProductBrief }) {

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
                                    <s style={{textDecorationColor : "red"}}>₴ {productBrief.price.toFixed(2)}</s>
                                </div>
                                <div><b><b>₴ {productBrief.actionPrice.toFixed(2)}</b></b></div>
                            </div>
                    }
                </div>
                <button className="btn btn-outline-success"><i className="bi bi-cart"></i></button>
            </div>
        </div>
    </div>
}