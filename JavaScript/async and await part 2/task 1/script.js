function multiplyAsync(a, b) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            if (typeof a !== "number" || typeof b !== "number") {
                reject(new Error("Incorrect values"));
            } else {
                resolve(a * b);
            }
        }, 2000);
    });
}

async function main() {
    try {
        const result = await multiplyAsync(6, 9);
        console.log("The result of multiplication:", result);
    } catch (error) {
        console.error(error.message);
    }
}

main();
