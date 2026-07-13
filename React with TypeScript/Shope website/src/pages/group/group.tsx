import { useParams } from "react-router-dom";
import "./ui/group.css";
import { useContext, useEffect, useState } from "react";
import type IGroupProduct from "../../entities/group/model/IGroupProduct";
import GroupApi from "../../entities/group/api/GroupApi";
import ProductCard from "./ui/ProductCard";
import GroupsWidget from "../../widgets/groups/GroupsWidget";
import AppContext from "../../features/_context/AppContext";

const preload_grp: IGroupProduct = {
    group: {
        id: "1",
        name: "Loading...",
        description: "Loading...",
        imageUrl: "/img/чорный_фон.png",
        slug: "Loading...",
    },

    products: Array.from({ length: 20 }, (_, i) => {
        return {
            id: i + 1 + "",
            name: "Loading...",
            description: "Loading...",
            imageUrl: "/img/чорный_фон.png",
            price: 0,
        }
    })
        
};


export default function Group() {
    const { slug } = useParams();
    const [groupProduct, setGroupProduct] = useState<IGroupProduct | undefined>(preload_grp);
    const { setLoading } = useContext(AppContext)

    useEffect(() => {
        setLoading(true)
        GroupApi.groupDetails(slug!)
            .then(setGroupProduct)
            .finally(() => { setLoading(false) });
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