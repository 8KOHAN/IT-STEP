import Base64 from "../../../shared/base64/Base64";
import { getUserFromJwt } from "../lib/UserLib";
import type IUser from "../model/IUser";
import type IUserSignupData from "../model/IUserSignupData";

export default class UserApi {
    static signUp(data: IUserSignupData): Promise<void> {
        return new Promise((resolve, reject) => {
            fetch("https://localhost:7132/User/SignUp", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(data),
            }).then(r => {
                if (r.ok) {
                    resolve();
                }
                else {
                    reject();
                }
            })
        });
    }

    static authenticate(login: string, password: string): Promise<IUser> {
        const credentials = Base64.encode(login + ':' + password)

        return new Promise<IUser>((resolve, reject) => {
            fetch("https://localhost:7132/User/BasicAuthJwt", {
                headers: {
                    "Authorization": "Basic " + credentials
                }
            }).then(async r => {
                if (r.ok) {
                    resolve(getUserFromJwt(await r.text()));
                }
                else {
                    reject(await r.text());
                }

            })
        })
    }

    static authenticateMock(login: string, password: string): Promise<IUser> {
        return new Promise<IUser>((resolve, reject) => {
            // одним з правил автентифікації - навмисно закладений відчутний час
            // самої процедури (близько 1с) з безпекових міркувань
            setTimeout(() => {
                // fetch -> JWT
                if (login == "user" && password == "123") {
                    let jwt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwiaWF0IjoxNzgzNDQwMDE5NTcxLCJleHAiOjE3ODQ2NDk2NjIwMDAsIm5hbWUiOiJFeHBlcmluY2VkIFVzZXIiLCJlbWFpbCI6InVzZXJAaS51YSJ9.gzSraSYS8EXBxLN_oWnFSRgCzcmJmMjLiuyu5CSpyHI";

                    resolve(getUserFromJwt(jwt))
                }
                else {
                    reject(401);
                }
            }, 1000);
        });
    }
}

/*
JWT
 header.payload.signature
 для фронтенда цікавий тільки payload:
 sub (Subject) - кому виданий токен (login)
 exp (Expiration Time)
 iat (Issued at)
 name
 email


header: {
  "alg": "HS256",
  "typ": "JWT"
} = eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9

payload = {
    sub: "user",
    iat: 1783440019571,
    exp: 1784649662000,
    name: "Experinced User",
    email: "user@i.ua"
} =>
{"sub":"user","iat":1783440019571,"exp":1784649662000,"name":"Experinced User","email":"user@i.ua"} 
eyJzdWIiOiJ1c2VyIiwiaWF0IjoxNzgzNDQwMDE5NTcxLCJleHAiOjE3ODQ2NDk2NjIwMDAsIm5hbWUiOiJFeHBlcmluY2VkIFVzZXIiLCJlbWFpbCI6InVzZXJAaS51YSJ9

signature = gzSraSYS8EXBxLN_oWnFSRgCzcmJmMjLiuyu5CSpyHI
*/