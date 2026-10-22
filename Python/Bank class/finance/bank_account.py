from __future__ import annotations

class BankAccount:
    def __init__(
        self,
        owner: str,
        account_number: str,
        initial_balance: float,
        currency: str
    ) -> None:
        if not owner.strip():
            raise ValueError("Ім'я власника не може бути порожнім.")

        if not account_number.strip():
            raise ValueError("Номер рахунку не може бути порожнім.")

        if initial_balance < 0:
            raise ValueError("Початковий баланс не може бути від'ємним.")

        if not currency.strip():
            raise ValueError("Валюта не може бути порожньою.")

        self.__owner: str = owner
        self.__account_number: str = account_number
        self.__balance: float = float(initial_balance)
        self.__currency: str = currency
        self.__active: bool = True

    # Властивості для доступу до приватних атрибутів
    @property
    def owner(self) -> str:
        return self.__owner

    @property
    def account_number(self) -> str:
        return self.__account_number

    @property
    def balance(self) -> float:
        return self.__balance

    @property
    def currency(self) -> str:
        return self.__currency

    @property
    def active(self) -> bool:
        return self.__active


    def deposit(self, amount: float) -> None:
        self.__check_active()

        if amount <= 0:
            raise ValueError(
                "Сума поповнення має бути більшою за нуль."
            )

        self.__balance += amount
        print(
            f"Рахунок поповнено на "
            f"{self.__currency}{amount:.2f}"
        )

    def withdraw(self, amount: float) -> None:
        self.__check_active()

        if amount <= 0:
            raise ValueError(
                "Сума зняття має бути більшою за нуль."
            )

        if amount > self.__balance:
            raise ValueError("Недостатньо коштів на рахунку.")

        self.__balance -= amount
        print(f"Знято {self.__currency}{amount:.2f}")

    def transfer_to(
        self,
        recipient: BankAccount,
        amount: float
    ) -> None:
        if not isinstance(recipient, BankAccount):
            raise ValueError(
                "Одержувач має бути банківським рахунком."
            )

        self.__check_active()
        recipient.__check_active()

        if recipient is self:
            raise ValueError(
                "Не можна переказати кошти на власний рахунок."
            )

        if recipient.currency != self.currency:
            raise ValueError(
                "Валюти рахунків мають збігатися."
            )

        if amount <= 0:
            raise ValueError(
                "Сума переказу має бути більшою за нуль."
            )

        if amount > self.__balance:
            raise ValueError(
                "Недостатньо коштів для переказу."
            )

        self.__balance -= amount
        recipient.__balance += amount

        print(
            f"Переказано {self.__currency}{amount:.2f}"
        )

    def print_info(self) -> None:
        print(f"Власник: {self.__owner}")
        print(f"Рахунок: {self.__account_number}")
        print(
            f"Баланс: {self.__currency}{self.__balance:.2f}"
        )
        print(
            f"Статус: {'активний' if self.__active else 'закритий'}"
        )

    def close_account(self) -> None:
        self.__check_active()

        if self.__balance != 0:
            raise ValueError(
                "Для закриття рахунку баланс має дорівнювати нулю."
            )

        self.__active = False
        print("Рахунок успішно закрито.")

    def __check_active(self) -> None:
        if not self.__active:
            raise ValueError(
                "Рахунок закритий. Операція неможлива."
            )
