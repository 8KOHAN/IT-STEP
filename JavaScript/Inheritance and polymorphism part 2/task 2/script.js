class ExtendedDate extends Date {
    getTextDate() {
        const months = [
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        ];

        return `${this.getDate()}
                ${months[this.getMonth()]}`;
    }

    isFuture() {
        return this >= new Date();
    }

    isLeapYear() {
        let year =
            this.getFullYear();

        return (
            year % 4 === 0 &&
            year % 100 !== 0
            ||
            year % 400 === 0
        );
    }

    getNextDate() {
        let next =
            new ExtendedDate(this);

        next.setDate(
            next.getDate() + 1
        );

        return next;
    }
}

let date =
    new ExtendedDate(
        2026,
        4,
        26
    );

document.write(
    date.getTextDate()
    + "<br>"
);

document.write(
    "Future date: "
    + date.isFuture()
    + "<br>"
);

document.write(
    "Leap year: "
    + date.isLeapYear()
    + "<br>"
);

document.write(
    "Next day: "
    + date.getNextDate()
        .toLocaleDateString()

    + "<br>"
);
