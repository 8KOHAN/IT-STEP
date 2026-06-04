function filterArray(array, callback) {
    const result = [];

    for (const item of array) {
        if (callback(item)) {
            result.push(item);
        }
    }

    return result;
}

function isEven(number) {
    return number % 2 === 0;
}

function isShortWord(word) {
    return word.length <= 4;
}

const numbers = [1, 2, 3, 4, 5, 6, 7, 8];
const evenNumbers = filterArray(numbers, isEven);

console.log(evenNumbers); 

const words = ["cat", "elephant", "dog", "tree", "computer"];
const shortWords = filterArray(words, isShortWord);

console.log(shortWords); 
