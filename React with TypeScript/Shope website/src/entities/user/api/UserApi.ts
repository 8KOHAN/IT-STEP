import type IUser from "../model/IUser";

export default class UserApi {

    static authenticate(login:string, password:string):Promise<IUser> {
        return new Promise<IUser>((resolve, reject) => {
            // одним з правил автентифікації - навмисно закладений відчутний час
            // самої процедури (близько 1с) з безпекових міркувань
            setTimeout(() => {
                // fetch -> JWT
                if(login == "user" && password == "123") {
                    let jwt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwiaWF0IjoxNzgzNDQwMDE5NTcxLCJleHAiOjE3ODQ2NDk2NjIwMDAsIm5hbWUiOiJFeHBlcmluY2VkIFVzZXIiLCJlbWFpbCI6InVzZXJAaS51YSJ9.gzSraSYS8EXBxLN_oWnFSRgCzcmJmMjLiuyu5CSpyHI";

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