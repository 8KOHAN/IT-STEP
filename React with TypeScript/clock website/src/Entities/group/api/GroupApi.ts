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
                        imageUrl: '/img/Fuji_Gaming_SingleImageCard_C-1._SY304_CB762596570_.jpg'
                    },
                    {
                        id: '2',
                        name: 'Jeans',
                        description: 'Shope Fashion for less',
                        slug: 'Jeans',
                        imageUrl: '/img/DQC_APR_TBYB_W_BOTTOMS_1x._SY116_CB624172947_.jpg'
                    },
                    
                    {
                        id: '3',
                        name: 'Watches',
                        description: 'Watches',
                        slug: 'Watches',
                        imageUrl: '/img/Watches_1x._SY116_CB566164844_.jpg'
                    },
                    
                    {
                        id: '4',
                        name: 'PS5',
                        description: 'PS5',
                        slug: 'PS5',
                        imageUrl: '/img/CE24_SUM_GW_DQC_SW_GamingWeek_Sony_v2_1x._SY116_CB558844445_.jpg'
                    },
                    {
                        id: '5',
                        name: 'Nintendo',
                        description: 'Nintendo',
                        slug: 'Nintendo',
                        imageUrl: '/img/CE24_SUM_GW_DQC_SE_GamingWeek_Nintendo_v2_1x._SY116_CB558844445_.jpg'
                    },
                    {
                        id: '6',
                        name: 'PC',
                        description: 'PC',
                        slug: 'PC',
                        imageUrl: '/img/CE24_SUM_GW_DQC_NW_GamingWeek_PC_v2_1x._SY116_CB558844445_.jpg'
                    },
                    {
                        id: '7',
                        name: 'Xbox',
                        description: 'Xbox',
                        slug: 'Xbox',
                        imageUrl: '/img/CE24_SUM_GW_DQC_NE_GamingWeek_Xbox_v2_1x._SY116_CB558844445_.jpg'
                    },
                    {
                        id: '8',
                        name: 'Books',
                        description: 'Books',
                        slug: 'Books',
                        imageUrl: '/img/Fuji_Defect_Reduction_1x_Books._SY116_CB549022351_.jpg'
                    },
                    {
                        id: '9',
                        name: 'Hats',
                        description: 'Hats',
                        slug: 'Hats',
                        imageUrl: '/img/Fuji_Quad_Hat_1x._SY116_CB667159060_.jpg'
                    },
                    {
                        id: '10',
                        name: 'Mugs',
                        description: 'Mugs',
                        slug: 'Jeans',
                        imageUrl: '/img/Fuji_Quad_Mug_1x._SY116_CB667159063_.jpg'
                    },
                ]),
                500
            )
        })
    }
}