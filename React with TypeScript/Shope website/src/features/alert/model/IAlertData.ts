import type IAlertButton from "./IAlertButton";

export default interface IAlertData {
    title?: string,
    message: string,
    buttons?: IAlertButton[],
}