function processArray(numbers, callback) {
    let results = [];
    for (let number of numbers) {
        results.push(callback(number));
    }
    return results;
}

function reverseElement(element) {
    let reverse = element.toString().split('').reverse().join('');
    return reverse;
}

function doubleElement(element) {
    return element * 2;
}

numbers = [18, 27, 36, 45, 54, 63, 72, 81];

let result = processArray(numbers, reverseElement);
for (let number of result) {
    console.log(number)
}
console.log('\n');

let result2 = processArray(numbers, doubleElement);
for (let number of result2) {
    console.log(number)
}
