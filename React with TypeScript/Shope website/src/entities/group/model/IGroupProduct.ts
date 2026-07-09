import type IGroup from "./IGroup";
import type IProductBrief from "./IProductBrief";

export default interface IGroupProduct {
    group: IGroup,
    products: Array<IProductBrief>
}