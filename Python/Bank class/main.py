from finance.bank_account import BankAccount

def main():
    try:
        account1 = BankAccount(
            "Олена",
            "UA001",
            1000.0,
            "₴"
        )

        account2 = BankAccount(
            "Андрій",
            "UA002",
            500.0,
            "₴"
        )

        print("=== Початкові дані ===")
        account1.print_info()

        print("\n=== Поповнення ===")
        account1.deposit(200)

        print("\n=== Зняття коштів ===")
        account1.withdraw(100)

        print("\n=== до операцій ===")
        account1.print_info()
        print()
        account2.print_info()

        print("\n=== Переказ ===")
        account1.transfer_to(account2, 300)

        print("\n=== Після операцій ===")
        account1.print_info()
        print()
        account2.print_info()

        print("\n=== Перевірка помилки ===")
        try:
            account1.withdraw(100000)
        except ValueError as error:
            print(f"Помилка: {error}")

    except ValueError as error:
        print(f"Помилка: {error}")


if __name__ == "__main__":
    main()
