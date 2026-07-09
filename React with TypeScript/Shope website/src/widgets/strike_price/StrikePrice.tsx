import type IProductBrief from "../../Entities/group/model/IProductBrief";
import "./ui/StrikePrice.css"

export default function StrikePrice({ productBrief }:
    { productBrief: IProductBrief }) {
    return (
        <div>
            {
                typeof productBrief.actionPrice == "undefined"
                    ? <div><b>₴{productBrief.price.toFixed(2)}</b></div>
                    : <div>
                        <div>
                            <div className="strike-price">₴{productBrief.price.toFixed(2)}</div>
                        </div>
                        <div><b><b>₴{productBrief.actionPrice.toFixed(2)}</b></b></div>
                    </div>
            }
        </div>
    )
}

export function StrikePriceRaw({ priceBefore, priceAfter }:
    { priceBefore: number, priceAfter: number }) {
    return (
        <div>
            {
                <div>
                    <div>
                        <div className="strike-price">₴{priceBefore.toFixed(2)}</div>
                    </div>
                    <div>
                        <b><b>₴{priceAfter.toFixed(2)}</b></b>
                    </div>
                </div>
            }
        </div>
    )
}