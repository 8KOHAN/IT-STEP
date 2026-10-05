import Base64 from "../../../shared/base64/Base64";
import type IUser from "../model/IUser";

function getUserFromJwt(jwt:string):IUser {
    // для фронтенда цікавий тільки payload: розділяємо токен за символом "." і беремо другу частину
    const payload = jwt.split('.')[1];
    const jsonString = Base64.decodeUrl(payload);
    const jsonObject = JSON.parse(jsonString);
    return {
        token: jwt,
        email: jsonObject.email,
        name: jsonObject.name,
        login: jsonObject.sub,
    };
}

function rememberUser(user:IUser):void {
    window.localStorage.setItem("p42-token", user.token);
}

function clearRememberedUser():void {
    window.localStorage.removeItem("p42-token");
}

function getRememberedUser():IUser|undefined {
    let token = window.localStorage.getItem("p42-token");
    if(token) {
        return getUserFromJwt(token);
    }
    return undefined;
}

export { getUserFromJwt, rememberUser, clearRememberedUser, getRememberedUser}