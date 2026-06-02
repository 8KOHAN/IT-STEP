// task 1
function division(a, b, onSuccess, onError) {
    if (b === 0) {
        onError("Division by zero is prohibited.");
    } else {
        let result = a / b;
        onSuccess(result);
    }
}

function onSuccess(result) {
    console.log(result);
}

function onError(error) {
    console.error(error);
}

division(10, 2, onSuccess, onError);
division(10, 0, onSuccess, onError);
console.log('\n');

// task 2
function processArray(numbers, callback) {
    let results = [];
    for (let number of numbers) {
        results.push(callback(number));
    }
    return results;
}

function logElement(element) {
    console.log(element)
}

function squareElement(element) {
    return element * element;
}

numbers = [1, 2, 3, 4, 5, 6, 7, 8];

processArray(numbers, logElement);

console.log('\n');
let result = processArray(numbers, squareElement);

for (let number of result) {
    console.log(number)
}
