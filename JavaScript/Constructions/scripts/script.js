// 1
let num = Number(prompt("enter number"));
if (num > 0) {
    alert("num > 0");
} else if (num === 0) {
    alert("num = 0");
} else {
    alert("num < 0");
}

// 2
let age = Number(prompt("enter your age"));

if (age > 0 && age < 160) {
    alert("I trust");
} else {
    alert("I don't trust");
}

// 3 
let number = Number(prompt("enter number"));
if (number > 0) {
    alert(number);
} else {
    alert(Math.abs(number));
}

//4
let hour = Number(prompt("enter hour"));
let min = Number(prompt("enter min"));
let sec = Number(prompt("enter sec"));

if (hour <= 0 || hour > 23) {
    alert("hour not corectly");
}

if (min <= 0 || min > 59) {
    alert("min not corectly");
}

if (sec <= 0 || sec > 59) {
    alert("sec not corectly");
}

// 5

let x = Number(prompt("Enter X coordinate:"));
let y = Number(prompt("Enter Y coordinate:"));

if (isNaN(x) || isNaN(y)) {
    alert("Enter numbers!");
} else if (x === 0 && y === 0) {
    alert("Point is at origin");
} else if (x === 0) {
    alert("Point is on Y axis");
} else if (y === 0) {
    alert("Point is on X axis");
} else if (x > 0 && y > 0) {
    alert("I quarter");
} else if (x < 0 && y > 0) {
    alert("II quarter");
} else if (x < 0 && y < 0) {
    alert("III quarter");
} else if (x > 0 && y < 0) {
    alert("IV quarter");
}


// SWITCH
// 1

let month = Number(prompt("Enter the month number (1-12):"));

if (isNaN(month)) {
    alert("This is not a number!");
} else {
    switch (month) {
        case 1:
            alert("January");
            break;
        case 2:
            alert("February");
            break;
        case 3:
            alert("March");
            break;
        case 4:
            alert("April");
            break;
        case 5:
            alert("May");
            break;
        case 6:
            alert("June");
            break;
        case 7:
            alert("July");
            break;
        case 8:
            alert("August");
            break;
        case 9:
            alert("September");
            break;
        case 10:
            alert("October");
            break;
        case 11:
            alert("November");
            break;
        case 12:
            alert("December");
            break;
        default:
            alert("Invalid month number");
    }
}

// 2

let num1 = Number(prompt("Enter first number:"));
let num2 = Number(prompt("Enter second number:"));
let operator = prompt("Enter operator (+, -, *, /):");

let result;

switch (operator) {
    case "+":
        result = num1 + num2;
        break;
    case "-":
        result = num1 - num2;
        break;
    case "*":
        result = num1 * num2;
        break;
    case "/":
        if (num2 === 0) {
            alert("Cannot divide by zero!");
            break;
        }
        result = num1 / num2;
        break;
    default:
        alert("Invalid operator!");
}

alert("Result: " + result);


// ? :
// 1

let number1 = Number(prompt("Enter first number:"));
let number2 = Number(prompt("Enter second number:"));

(number1 > number2) ? alert("Larger number: " + number1): alert("Larger number: " + number2);

// 2 
let num67 = Number(prompt("Enter a number:"));

(num67 % 5 === 0) ? alert("Divisible by 5"): alert("Not divisible by 5");

// 3
let planet = prompt("Enter planet name:");

(planet === "Earth" || planet === "earth") ?
alert("Hello, Earthling!"): alert("Hello, alien!");
