export {}

declare global {
    interface Number {
        pad2: () => string,
    }
}

Number.prototype.pad2 = function(): string {
    return this.valueOf().toFixed(2);
}