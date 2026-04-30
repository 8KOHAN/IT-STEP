alert('Hello, World!');
console.warn('Warning!!!');
console.error('syper Error!');

//1
let number = Number(prompt("input num"));
console.log(number ** 2);

//2
let num1 = Number(prompt("input num1"));
let num2 = Number(prompt("input num2"));
console.log((num1+num2)/2);

//3
let area = Number(prompt("input area"));
console.log(area*area);

//4
const mil = 0.621371
let kilometr = Number(prompt("input kilometr"));
console.log(kilometr * mil);

//5
let a = Number(prompt("input number a"));
let b = Number(prompt("input number b"));
console.log(a+b);
console.log(a-b);
console.log(a*b);
console.log(a/b);

//6
a = Number(prompt("input number a"));
b = Number(prompt("input number b"));
console.log(-b / a);

//7 
let hour = Number(prompt("input hour (0-23)"));
let min = Number(prompt("input min (0-59)"))
console.log(`hour to new day - ${23 - hour}, min to new day - ${59 - min}`)

//8
let n = Number(prompt("promt num (100 - 999)"));
console.log(Math.floor((n % 100) / 10));

//9
n = Number(prompt("promt num (10_000 - 99_999)"));
console.log((n % 10) * 10000 + Math.floor(n / 10));

//10
let sale = Number(prompt("input sale"))
console.log(250 + (sale * 0.1))
