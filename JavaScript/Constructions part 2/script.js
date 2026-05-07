// 1. 
function compareNumbers(a, b) {
    if (a < b) {
        return -1;
    } else if (a > b) {
        return 1;
    }

    return 0;
}

console.log(compareNumbers(5, 10));
console.log(compareNumbers(10, 5));
console.log(compareNumbers(7, 7));


// 2. 
function factorial(number) {
    let result = 1;

    for (let i = 1; i <= number; i++) {
        result *= i;
    }

    return result;
}

console.log(factorial(5));


// 3. 
function createNumber(a, b, c) {
    return Number("" + a + b + c);
}

console.log(createNumber(1, 4, 9));


// 4. 
function rectangleArea(length, width = length) {
    return length * width;
}

console.log(rectangleArea(5, 10));
console.log(rectangleArea(5));


// 5.
function isPerfectNumber(number) {
    let sum = 0;

    for (let i = 1; i < number; i++) {
        if (number % i === 0) {
            sum += i;
        }
    }

    return sum === number;
}

console.log(isPerfectNumber(6));
console.log(isPerfectNumber(28));
console.log(isPerfectNumber(10));


// 6. 
function showPerfectNumbers(min, max) {
    for (let i = min; i <= max; i++) {
        if (isPerfectNumber(i)) {
            console.log(i);
        }
    }
}

showPerfectNumbers(1, 1000);


// 7. 
function showTime(hours, minutes = 0, seconds = 0) {
    let h = String(hours).padStart(2, "0");
    let m = String(minutes).padStart(2, "0");
    let s = String(seconds).padStart(2, "0");

    return `${ h }: ${ m }: ${ s }`;
}

console.log(showTime(10, 25, 30));
console.log(showTime(8));


// 8. 
function timeToSeconds(hours, minutes, seconds) {
    return (hours * 3600) + (minutes * 60) + seconds;
}

console.log(timeToSeconds(1, 30, 20));


// 9.
function secondsToTime(totalSeconds) {
    let hours = Math.floor(totalSeconds / 3600);
    let minutes = Math.floor((totalSeconds % 3600) / 60);
    let seconds = totalSeconds % 60;

    return showTime(hours, minutes, seconds);
}

console.log(secondsToTime(5420));


// 10.
function timeDifference(h1, m1, s1, h2, m2, s2) {
    let firstTime = timeToSeconds(h1, m1, s1);
    let secondTime = timeToSeconds(h2, m2, s2);

    let difference = Math.abs(firstTime - secondTime);

    return secondsToTime(difference);
}

console.log(timeDifference(10, 20, 30, 12, 10, 15));
