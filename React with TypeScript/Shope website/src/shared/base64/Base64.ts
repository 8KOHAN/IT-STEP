export default class Base64 {
    static #textEncoder = new TextEncoder();
    static #textDecoder = new TextDecoder();

    // https://datatracker.ietf.org/doc/html/rfc4648#section-4
    static encode = (str:string) => btoa(String.fromCharCode(...Base64.#textEncoder.encode(str)));
    static decode = (str:string) => Base64.#textDecoder.decode(Uint8Array.from(atob(str), c => c.charCodeAt(0)));
    
    // https://datatracker.ietf.org/doc/html/rfc4648#section-5
    static encodeUrl = (str:string) => this.encode(str).replace(/\+/g, '-').replace(/\//g, '_').replace(/=+$/, '');
    static decodeUrl = (str:string) => this.decode(str.replace(/\-/g, '+').replace(/\_/g, '/'));
}