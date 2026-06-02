function createOrder(orderId) {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve(`The order has been created: ${ orderId }`);
        }, 1000);
    });
}

function processOrder(orderId) {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve(`Order processed: ${orderId}`);
        }, 2000);
    });
}

function deliverOrder(orderId) {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve(`Order delivered: ${orderId}`);
        }, 3000);
    });
}


const orderId = 67;

createOrder(orderId)
    .then((message) => {
        console.log(message);
        return processOrder(orderId);
    })
    .then((message) => {
        console.log(message);
        return deliverOrder(orderId);
    })
    .then((message) => {
        console.log(message);
    })
    .catch((error) => {
        console.error(error);
    });
