class PrintMachine {
    constructor(fontSize, color, fontFamily) {
        this.fontSize = fontSize;
        this.color = color;
        this.fontFamily = fontFamily;
    }

    print(text) {
        document.write(`
            <p style="
                font-size:${this.fontSize}px;
                color:${this.color};
                font-family:${this.fontFamily}">
                ${text}
            </p>
        `);
    }
}

let printer = new PrintMachine(
    24,
    "red",
    "Arial"
);

printer.print("Hello, world!");
