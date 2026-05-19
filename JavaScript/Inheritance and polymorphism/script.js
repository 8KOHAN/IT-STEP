// 2
class Figure {
    constructor(name) {
        this._name = name;
    }

    get name() {
        return this._name;
    }

    showInfo() {
        console.log(`Figure: ${this.name}`);
    }

    getArea() {
        return 0;
    }

    getPerimeter() {
        return 0;
    }
}

class Square extends Figure {
    constructor(side) {
        super("Square");

        this.side = side;
    }

    showInfo() {
        console.log(`
            Figure: ${this.name}
            Side: ${this.side}
            Area: ${this.getArea()}
            Perimeter: ${this.getPerimeter()}
        `);
    }

    getArea() {
        return this.side ** 2;
    }

    getPerimeter() {
        return this.side * 4;
    }

}

class Rectangle extends Figure {
    constructor(width, height) {
        super("Rectangle");

        this.width = width;
        this.height = height;
    }

    showInfo() {
        console.log(`
            Figure: ${this.name}
            Width: ${this.width}
            Height: ${this.height}
            Area: ${this.getArea()}
            Perimeter: ${this.getPerimeter()}
        `);

    }

    getArea() {
        return this.width * this.height;
    }

    getPerimeter() {
        return (
            (this.width + this.height) * 2
        );
    }

}

class Triangle extends Figure {
    constructor(a,b,c) {

        super("Triangle");

        this.a = a;
        this.b = b;
        this.c = c;
    }

    showInfo() {
        console.log(`
            Figure: ${this.name}
            Sides:
            ${this.a}
            ${this.b}
            ${this.c}

            Area: ${this.getArea()}
            Perimeter: ${this.getPerimeter()}
        `);
    }

    getPerimeter() {
        return (
            this.a+
            this.b+
            this.c
        );
    }

    getArea() {
        let p =
            this.getPerimeter()/2;

        return Math.sqrt(
            p*
            (p-this.a)*
            (p-this.b)*
            (p-this.c)
        );
    }
}

const figures= [
    new Square(5),

    new Rectangle(
        10,
        4
    ),

    new Triangle(
        3,
        4,
        5
    )
];


for(let figure of figures){
    figure.showInfo();
}


// 3
class ExtendedArray extends Array{
    getString(separator){

        return this.join(
            separator
        );

    }

    getHtml(tagName){
        let html="";

        for(let item of this){
            html += `<${tagName}>${item}</${tagName}>`;
        }

        if(tagName==="li"){
            html=
            `<ul>${html}</ul>`;
        }
        return html;
    }
}

const arr=
new ExtendedArray(
    "Apple",
    "Orange",
    "Banana"
);

console.log(
    arr.getString(", ")
);

console.log(
    arr.getString(" - ")
);

console.log(
    arr.getHtml("p")
);

console.log(
    arr.getHtml("li")
);
