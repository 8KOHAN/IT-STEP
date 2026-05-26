class Circle {
constructor(radius) {
this._radius = radius;
}

get radius() {
return this._radius;
}

set radius(value) {
if (value > 0) {
this._radius = value;
} else {
console.log("Radius must be greater than 0");
}
}

get diameter() {
return this._radius * 2;
}

getArea() {
return Math.PI * this._radius ** 2;
}

getLength() {
return 2 * Math.PI * this._radius;
}
}

let circle = new Circle(10);

console.log("Radius:", circle.radius);

circle.radius = 15;
console.log("New radius:", circle.radius);

console.log("Diameter:", circle.diameter);

console.log(
"Area:",
circle.getArea().toFixed(2)
);

console.log(
"Length:",
circle.getLength().toFixed(2)
);
