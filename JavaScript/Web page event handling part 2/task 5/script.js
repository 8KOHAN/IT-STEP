const books = document.querySelectorAll(".book");

books.forEach(book => {
    book.addEventListener("click", () => {

        books.forEach(item =>
            item.classList.remove("selected")
        );

        book.classList.add("selected");
    });
});
