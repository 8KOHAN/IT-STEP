import type IUser from "../model/IUser";

export default class UserApi {

    static authenticate(login: string, password: string): Promise<IUser> {
        return new Promise<IUser>((resolve, reject) => {
            setTimeout(() => {
                let jwt = "";
            }, 1000);
        })
    }
}


// payload = {
//     sub: "user",
//     iat: 1783440019571, 
//     exp: 1784649662000, 
//     name: "Experinced User", 
//     email: "user@i.ua"
// } = "eyJzdWIiOiJ1c2VyIiwiaWF0IjoxNzgzNDQwMDE5NTcxLCJleHAiOjE3ODQ2NDk2NjIwMDAsIm5hbWUiOiJFeHBlcmluY2VkIFVzZXIiLCJlbWFpbCI6InVzZXJAaS51YSJ9"