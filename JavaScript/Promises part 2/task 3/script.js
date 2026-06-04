function washDishes() {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve("The dishes are washed");
        }, 2000);
    });
}

function cleanRoom() {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve("The room is cleaned");
        }, 4000);
    });
}

function makeDinner() {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve("Dinner is ready");
        }, 7000);
    });
}

washDishes()
    .then((message) => {
        console.log(message);
        return cleanRoom();
    })
    .then((message) => {
        console.log(message);
        return makeDinner();
    })
    .then((message) => {
        console.log(message);
    })
    .catch((error) => {
        console.error(error);
    });
