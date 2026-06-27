import { useParams } from "react-router-dom";
import "./ui/group.css";
import { useEffect, useState } from "react";
import type IGroupProduct from "../../Entities/group/model/IGroupProduct";
import GroupApi from "../../Entities/group/api/GroupApi";
import ProductCard from "./ui/ProductCard";
import GroupsWidget from "../../Widgets/groups/GroupsWidget";

export default function Group() {
    const { slug } = useParams();
    const [groupProduct, setGroupProduct] = useState<IGroupProduct | undefined>();

    useEffect(() => {
        GroupApi.groupDetails(slug!).then(setGroupProduct);
    }, []);

    return (
        <div className="conteiner cards-conteiner">
            <h1>{slug}</h1>
            {groupProduct
                ? <>
                    <GroupsWidget />
                    <GroupView groupProduct={groupProduct} />
                </>
                : <p>Loading...</p>}
        </div>
    )
}

function GroupView({ groupProduct }: { groupProduct: IGroupProduct }) {
    return <div className="cards row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4 row-cols-md-3 row-cols-xxl-5 g-4">
        {groupProduct.products.map(gp => <ProductCard productBrief={gp} key={gp.id} />)}
    </div>
}