function sortArray(array) {
    return new Promise((resolve, reject) => {
        if (array.length === 0) {
            reject("Array is empty");
            return;
        }

        setTimeout(() => {
            const sortedArray = [...array].sort((a, b) => a - b);
            resolve(sortedArray);
        }, 2000);
    });
}

sortArray([5, 3, 8, 1, 4])
    .then((sorted) => {
        console.log(sorted);
    })
    .catch((error) => {
        console.log(error);
    });

sortArray([])
    .then((sorted) => {
        console.log(sorted);
    })
    .catch((error) => {
        console.log(error);
    });
