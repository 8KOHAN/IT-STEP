from dataclasses import dataclass


@dataclass
class Rectangle:
    __width: float
    __height: float

    def __init__(self, width: float, height: float):
        self.width = width
        self.height = height

    @property
    def width(self) -> float:
        return self.__width

    @width.setter
    def width(self, value: float):
        if type(value) is not float:
            raise TypeError("Width must be a float")
        if value < 0:
            raise ValueError("Width cannot be less than 0")
        self.__width = value

    @property
    def height(self) -> float:
        return self.__height

    @height.setter
    def height(self, value: float):
        if type(value) is not float:
            raise TypeError("Height must be a float")
        if value < 0:
            raise ValueError("Height cannot be less than 0")
        self.__height = value

    def get_area(self) -> float:
        return self.__width * self.__height

    def get_perimeter(self) -> float:
        return 2 * (self.__width + self.__height)