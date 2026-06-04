function task1() {
    return new Promise(resolve =>
        setTimeout(() => resolve("task 1 end"), 1000));
}

function task2() {
    return new Promise(resolve =>
        setTimeout(() => resolve("task 2 end"), 2000));
}

function task3() {
    return new Promise(resolve =>
        setTimeout(() => resolve("task 3 end"), 3000));
}

async function executeTasks() {
    const t1 = await task1();
    console.log(t1);
    const t2 = await task2();
    console.log(t2);
    const t3 = await task3();
    console.log(t3);
}

executeTasks()
