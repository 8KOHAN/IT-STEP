function sortArrayAsync(array) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (array.length === 0) {
                reject(new Error("Array is empty"));
            } else {
                const sortedArray = [...array].sort((a, b) => a - b);
                resolve(sortedArray);
            }
        }, 2000);
    });
}

async function main() {
    try {
        const numbers = [7, 3, 9, 1, 5];
        const result = await sortArrayAsync(numbers);
        console.log("Sorted array:", result);
    } catch (error) {
        console.error(error.message);
    }
}

main();
