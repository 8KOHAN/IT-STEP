import type IGroup from "../model/IGroup";

export default class GroupApi {
    static allGroups(): Promise<Array<IGroup>> {
        return new Promise<Array<IGroup>> ( (resolve, reject) => {
            setTimeout(
                () => resolve([
                    {
                        id: '1',
                        name: 'Shope gaming',
                        description: 'Get your game on',
                        slug: 'game',
                        imageUrl: 'public\img\Fuji_Gaming_SingleImageCard_C-1._SY304_CB762596570_.jpg'
                    },
                    {
                        id: '2',
                        name: 'Jeans',
                        description: 'Shope Fashion for less',
                        slug: 'Jeans',
                        imageUrl: 'public\img\DQC_APR_TBYB_W_BOTTOMS_1x._SY116_CB624172947_.jpg'
                    },
                ]),
                500
            )
        })
    }
}