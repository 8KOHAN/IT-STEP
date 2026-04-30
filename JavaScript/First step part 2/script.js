//1 
let name = prompt("Enter your name");
alert(`Hello, ${name}!`);

//2
const CURRENT_YEAR = 2026;
let birthYear = Number(prompt("Enter your birth year"));
let age = CURRENT_YEAR - birthYear;
alert(`You are ${age} years old`);

//3
let side = Number(prompt("Enter the side length of the square"));
alert(`Square perimeter = ${4 * side}`);

//4
const PI = 3.14159;
let radius = Number(prompt("Enter the radius of the circle"));
alert(`Circle area = ${PI * radius ** 2}`);

//5
let distance = Number(prompt("Enter distance (km)"));
let time = Number(prompt("How many hours do you have?"));
alert(`Required speed = ${distance / time} km/h`);

//6
const RATE = 0.92;
let dollars = Number(prompt("Enter amount in dollars"));
alert(`In euros = ${dollars * RATE}`);

//7
let gb = Number(prompt("Enter flash drive size (GB)"));
let mb = gb * 1024;
alert(`Files that fit: ${Math.floor(mb / 820)}`);

//8
let money = Number(prompt("Enter your money amount"));
let price = Number(prompt("Enter price of one chocolate"));
let count = Math.floor(money / price);
let change = money % price;
alert(`You can buy ${count} chocolates, change: ${change}`);

//9
let num = Number(prompt("Enter a three-digit number"));
let reversed = (num % 10) * 100 + Math.floor((num % 100) / 10) * 10 + Math.floor(num / 100);
alert(`Reversed number: ${reversed}`);
