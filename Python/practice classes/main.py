from geometry.rectangle import Rectangle


def main():
    rectangle = Rectangle(width=5.0, height=3.0)

    print("Прямокутник:", rectangle)
    print("Ширина:", rectangle.width)
    print("Висота:", rectangle.height)
    print("Площа:", rectangle.get_area())
    print("Периметр:", rectangle.get_perimeter())


if __name__ == "__main__":
    main()