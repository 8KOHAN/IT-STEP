import type IGroup from "../model/IGroup";
import type IGroupProduct from "../model/IGroupProduct";

const groups: Array<IGroup> = [
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
        name: 'PS5-Game',
        description: 'PS5-Game',
        slug: 'PS5-Game',
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
        slug: 'Mugs',
        imageUrl: '/img/Fuji_Quad_Mug_1x._SY116_CB667159063_.jpg'
    },
]

const groupProducts: Record<string,IGroupProduct> = {
    "PS5-Game": {
        group: groups[3],
        products: [
            {
                id: "4-1",
                name: "Mario",
                description: "Культова платформна гра про пригоди Маріо.",
                slug: "mario",
                imageUrl: "/img/Gemini_Generated_Image_Mario.png",
                price: 49.99,
                actionPrice: 1299,
                stock: 15,
            },
            {
                id: "4-2",
                name: "Hollow Knight",
                imageUrl: "/img/Gemini_Generated_Image_Hollow_knight.png",
                price: 14.99,
                stock: 12,
            },
            {
                id: "4-3",
                name: "GTA 6",
                description: "Очікувана гра з відкритим світом від Rockstar Games.",
                imageUrl: "/img/Gemini_Generated_Image_GTA_6.png",
                price: 79.99,
            },
            {
                id: "4-4",
                name: "Fortnite",
                slug: "fortnite",
                imageUrl: "/img/Gemini_Generated_Image_Fortnite.png",
                price: 0,
                stock: 999,
            },
            {
                id: "4-5",
                name: "Sonic Frontiers",
                description: "Пригодницька гра про Соніка у відкритому світі.",
                slug: "sonic-frontiers",
                imageUrl: "/img/Gemini_Generated_Image_Sonic_Frontiers.png",
                price: 69.99,
                actionPrice: 1199,
            },
            {
                id: "4-6",
                name: "Hollow Knight Silksong",
                description: "Продовження популярної метроідванії.",
                imageUrl: "/img/Gemini_Generated_Image_Hollow_Knight_Silksong.png",
                price: 69.99,
                stock: 20,
            },
            {
                id: "4-7",
                name: "It Takes Two",
                slug: "it-takes-two",
                imageUrl: "/img/Gemini_Generated_Image_It_Takes_Two.png",
                price: 39.99,
                actionPrice: 899,
                stock: 14,
            },
            {
                id: "4-8",
                name: "Ratchet&Clank Rift Apart",
                description: "Яскравий екшен-платформер для PlayStation.",
                imageUrl: "/img/Gemini_Generated_Image_Ratchet_clank_Rift_Apart.png",
                price: 69.99,
            },
            {
                id: "4-9",
                name: "Goat Simulator 3",
                slug: "goat-simulator-3",
                imageUrl: "/img/Gemini_Generated_Image_Goat_Simulator_3.png",
                price: 49.99,
                stock: 11,
            },
            {
                id: "4-10",
                name: "Stray",
                description: "Пригодницька гра про кота у кіберпанковому світі.",
                slug: "stray",
                imageUrl: "/img/Gemini_Generated_Image_Stray.png",
                price: 799,
                actionPrice: 29.99,
                stock: 9,
            },
        ]
    }

}

export default class GroupApi {
    static allGroups(): Promise<Array<IGroup>> {
        return new Promise<Array<IGroup>>((resolve, reject) => {
            setTimeout(
                () => resolve(groups),
                500
            )
        })
    }

    static groupDetails(slug: string): Promise<IGroupProduct> {
        return new Promise<IGroupProduct>((resolve, reject) => {
            setTimeout(
                () => {
                    let group = groups.find(g => g.slug == slug);
                    if (group) {
                        resolve({
                            group,
                            products: typeof groupProducts[slug] == "undefined" ? [] : groupProducts[slug].products,
                        });
                    }
                    else {
                        reject("Not Found");
                    }
                },
                500
            );
        });

    }
}
