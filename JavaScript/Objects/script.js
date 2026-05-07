const rectangle = {
    topLeft: {
        x: 2,
        y: 8
    },

    bottomRight: {
        x: 10,
        y: 2
    }
};

// 1. 
function printRectangleInfo(rect) {
    console.log("Top left point:");
    console.log(`X: ${ rect.topLeft.x }, Y: ${ rect.topLeft.y }`);

    console.log("Bottom right point:");
    console.log(`X: ${ rect.bottomRight.x }, Y: ${ rect.bottomRight.y }`);
}

// 2.
function getWidth(rect) {
    return rect.bottomRight.x - rect.topLeft.x;
}

// 3. 
function getHeight(rect) {
    return rect.topLeft.y - rect.bottomRight.y;
}


// 4. 
function getArea(rect) {
    return getWidth(rect) * getHeight(rect);
}


// 5. 
function getPerimeter(rect) {
    return 2 * (getWidth(rect) + getHeight(rect));
}


// 6. 
function changeWidth(rect, value) {
    rect.bottomRight.x += value;
}


// 7. 
function changeHeight(rect, value) {
    rect.bottomRight.y -= value;
}


// 8. 
function changeSize(rect, widthValue, heightValue) {
    changeWidth(rect, widthValue);
    changeHeight(rect, heightValue);
}


// 9. 
function moveX(rect, value) {
    rect.topLeft.x += value;
    rect.bottomRight.x += value;
}


// 10. 
function moveY(rect, value) {
    rect.topLeft.y += value;
    rect.bottomRight.y += value;
}

// 11.
function move(rect, xValue, yValue) {
    moveX(rect, xValue);
    moveY(rect, yValue);
}


// 12.
function isPointInside(rect, x, y) {
    return (
        x >= rect.topLeft.x &&
        x <= rect.bottomRight.x &&
        y <= rect.topLeft.y &&
        y >= rect.bottomRight.y
    );
}

printRectangleInfo(rectangle);

console.log("Width:", getWidth(rectangle));
console.log("Height:", getHeight(rectangle));
console.log("Area:", getArea(rectangle));
console.log("Perimeter:", getPerimeter(rectangle));

changeWidth(rectangle, 5);

changeHeight(rectangle, 3);

move(rectangle, 2, -1);

printRectangleInfo(rectangle);

console.log(
    "Point inside:",
    isPointInside(rectangle, 5, 5)
);
