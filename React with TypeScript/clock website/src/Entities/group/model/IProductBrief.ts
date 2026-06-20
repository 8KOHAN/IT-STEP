export default interface IProductBrief {
    id: string,
    name: string,
    description?: string,
    slug?: string,
    imageUrl?: string,
    price: number,
    actionPrice?: number,
    stock?: number

};