class AlarmClock:
    def beep(self) -> None:
        print("Будильник пікає!")

class Cat:
    def meow(self) -> None:
        print("Мяу!")

class CatAlarmClock(AlarmClock, Cat):
    def beep(self) -> None:
        print("4:00 ранку! пуу-пуу-пуу")

    def meow(self) -> None:
        print("МЯУУУ! ГОСПОДАРЮ, Я ХОЧУ ЇСТИ!")


if __name__ == "__main__":
    cat_alarm = CatAlarmClock()

    cat_alarm.beep()
    cat_alarm.meow()