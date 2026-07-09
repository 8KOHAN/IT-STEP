import Base64 from "../../../shared/base64/Base64";
import type IUser from "../model/IUser";

function getUserFromJwt(jwt: string): IUser {
    const payload = jwt.split(".")[1];
    const jsonString = Base64.decodeUrl(payload);
    const jsonObject = JSON.parse(jsonString);
    return{
        token: jwt,
        email: jsonObject.email,
        name: jsonObject.name,
        login: jsonObject.sub,
    };
}

export {getUserFromJwt, }