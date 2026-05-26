class Marker {

    constructor(color, inkAmount = 100) {
        this.color = color;
        this.inkAmount = inkAmount;
    }

    print(text) {

        let printedText = "";

        for (let char of text) {

            if (this.inkAmount <= 0)
                break

            printedText += char;

            if (char !== " ") {

                this.inkAmount -= 0.5;

            }
        }

        document.write(`
            <p style="
                color:${this.color};
                font-size:20px">
                ${printedText}
            </p>
        `);

        document.write(`
            Remaining ink:
            ${this.inkAmount}%<br>
        `);
    }
}

class RefillableMarker
    extends Marker {

    refill(percent) {
        this.inkAmount += percent;

        if (this.inkAmount > 100) {
            this.inkAmount = 100;
        }
    }

}

let marker =
    new Marker("orange", 10);

marker.print(
    "long text"
);
let refillMarker =
    new RefillableMarker(
        "red",
        5
    );

refillMarker.print(
    "short text"
);

refillMarker.refill(50);

document.write(
    "After refilling:<br>"
);

refillMarker.print(
    "The marker is working again!"
);
