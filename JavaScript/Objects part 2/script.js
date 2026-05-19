// 1
const car = {
    manufacturer: "Toyota",
    model: "Camry",
    year: 2020,
    averageSpeed: 80
};

function showCarInfo(car) {
    console.log(`
    Manufacturer: ${car.manufacturer}
    Model: ${car.model}
    Year: ${car.year}
    Average speed: ${car.averageSpeed} km/h`
    );
}

function calculateTravelTime(car, distance) {
    let drivingHours = distance / car.averageSpeed;
    let breaks = Math.floor(drivingHours / 4);
    let totalTime = drivingHours + breaks;

    return totalTime;
}

showCarInfo(car);

console.log(
    "Travel time:",
    calculateTravelTime(car, 1000),
    "hours"
);


// TASK 2
const fraction1 = {
    numerator: 1,
    denominator: 2
};

const fraction2 = {
    numerator: 3,
    denominator: 4
};

function gcd(a, b) {
    while (b !== 0) {
        let temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

function reduceFraction(fraction) {
    let divisor = gcd(
        fraction.numerator,
        fraction.denominator
    );
    return {
        numerator:
            fraction.numerator / divisor,

        denominator:
            fraction.denominator / divisor
    };
}

function addFractions(f1, f2) {
    let result = {
        numerator:
            f1.numerator * f2.denominator +
            f2.numerator * f1.denominator,

        denominator:
            f1.denominator * f2.denominator
    };
    return reduceFraction(result);
}

function subtractFractions(f1, f2) {
    let result = {
        numerator:
            f1.numerator * f2.denominator -
            f2.numerator * f1.denominator,

        denominator:
            f1.denominator * f2.denominator
    };
    return reduceFraction(result);
}


// Multiply fractions
function multiplyFractions(f1, f2) {
    let result = {
        numerator:
            f1.numerator * f2.numerator,

        denominator:
            f1.denominator * f2.denominator
    };
    return reduceFraction(result);
}


// Divide fractions
function divideFractions(f1, f2) {

    let result = {
        numerator:
            f1.numerator * f2.denominator,

        denominator:
            f1.denominator * f2.numerator
    };

    return reduceFraction(result);
}


console.log(
    addFractions(fraction1, fraction2)
);

console.log(
    subtractFractions(fraction1, fraction2)
);

console.log(
    multiplyFractions(fraction1, fraction2)
);

console.log(
    divideFractions(fraction1, fraction2)
);


// 3
const time = {
    hours: 20,
    minutes: 30,
    seconds: 45
};

function showTime(time) {
    let h =
        String(time.hours)
        .padStart(2, "0");
    let m =
        String(time.minutes)
        .padStart(2, "0");
    let s =
        String(time.seconds)
        .padStart(2, "0");

    console.log(`${h}:${m}:${s}`);
}

function toSeconds(time) {
    return (
        time.hours * 3600 +
        time.minutes * 60 +
        time.seconds
    );
}

function fromSeconds(totalSeconds) {
    totalSeconds =
        totalSeconds % (24 * 3600);

    time.hours =
        Math.floor(totalSeconds / 3600);
    time.minutes =
        Math.floor(
            (totalSeconds % 3600) / 60
        );
    time.seconds =
        totalSeconds % 60;
}

function addSeconds(time, sec) {
    let total =
        toSeconds(time);
    total += sec;

    fromSeconds(total);
}

function addMinutes(time, min) {
    addSeconds(
        time,
        min * 60
    );
}

function addHours(time, hours) {
    addSeconds(
        time,
        hours * 3600
    );
}

showTime(time);

addSeconds(time,30);

showTime(time);

addMinutes(time,40);

showTime(time);

addHours(time,5);
