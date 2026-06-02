function checkEvenNumber(number) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (number % 2 === 0) {
                resolve(`An even number: ${number}`);
            } else {
                reject(`An odd number: ${number}`);
            }
        }, 1000);
    });
}

checkEvenNumber(8)
    .then((message) => {
        console.log(message);
    })
    .catch((error) => {
        console.log(error);
    });

checkEvenNumber(7)
    .then((message) => {
        console.log(message);
    })
    .catch((error) => {
        console.log(error);
    });
