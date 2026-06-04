function sumArrayAsync(array) {
    return new Promise((resolve, reject) => {
        if (array.length === 0) {
            reject('array is empty');
        }
        let count = 0;
        let index = 0;
        function addNext() {
            if (index >= array.length) {
                resolve(count);
                return;
            }
            setTimeout(() => {
                count += array[index];
                index++;
                addNext();
            }, 1000);
        }
        addNext()
    })
}

async function main() {
    let array = [2, 4, 6, 8];
    const result = await sumArrayAsync(array);
    console.log(result);
}

main()
