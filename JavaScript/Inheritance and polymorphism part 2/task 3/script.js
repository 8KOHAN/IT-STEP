class Employee {
    constructor(
        name,
        position,
        salary
    ) {
        this.name = name;
        this.position = position;
        this.salary = salary;
    }
}

class EmpTable {
    constructor(employees) {
        this.employees =
            employees;
    }

    getHtml() {

        let html = `

        <table border="1">
        <tr>
            <th>Name</th>
            <th>Position</th>
            <th>Salary</th>
        </tr>
        `;

        this.employees
            .forEach(emp => {
                html += `
                <tr>
                    <td>${emp.name}</td>
                    <td>${emp.position}</td>
                    <td>${emp.salary}</td>
                </tr>
                `;

            });

        html += "</table>";
        return html;
    }
}

let employees = [
    new Employee(
        "Ivan Petrenko",
        "Manager",
        25000
    ),
    new Employee(
        "Olena Koval",
        "Cashier",
        18000
    ),
    new Employee(
        "Andriy Shevchenko",
        "Director",
        45000
    )
];

let table =
    new EmpTable(
        employees
    );

document.write(
    table.getHtml()
);
