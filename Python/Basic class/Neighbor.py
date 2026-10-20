from dataclasses import dataclass


@dataclass
class Neighbor:
    name: str
    favorite_activity: str
    noise_level: int
    current_time: str

    def make_noise(self):
        print(
            f"{self.current_time}. {self.name} решил заняться делом: "
            f"{self.favorite_activity}. "
            f"Уровень шума — {self.noise_level}/10. "
            "Соседи снизу уже пересматривают своё отношение к жизни."
        )

    def explain_himself(self):
        print(
            f"{self.name}: «Я вообще-то тихо хожу! "
            "Это у вас потолок какой-то нервный»."
        )

    def start_repairs(self):
        print(
            f"{self.name} начал ремонт. "
            "Сегодня в планах — просверлить стену, "
            "за которой, по его мнению, находится космос."
        )

    def react_to_complaint(self):
        print(
            f"{self.name} услышал стук по батарее и замер. "
            "Через минуту постучал в ответ: "
            "«Чего стучите? Я вообще-то тоже жаловаться хотел!»"
        )


if __name__ == "__main__":
    neighbor1 = Neighbor(
        "Виктор", "передвигать шкаф в 02:47", 10, "02:47"
    )
    neighbor2 = Neighbor(
        "Сергей", "собирать мебель без инструкции", 8, "23:15"
    )
    neighbor3 = Neighbor(
        "Аркадий", "сверлить несущую стену в воскресенье", 11, "08:03"
    )

    neighbor1.make_noise()
    neighbor1.explain_himself()
    print("\n#########################################\n")

    neighbor2.start_repairs()
    neighbor2.react_to_complaint()
    print("\n#########################################\n")

    neighbor3.make_noise()
    neighbor3.react_to_complaint()
