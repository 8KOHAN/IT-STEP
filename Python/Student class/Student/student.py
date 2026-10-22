class Student:
    def __init__(self, grades: list[int]):
        self.grades = grades

    def __getitem__(self, index: int) -> int:
        return self.grades[index]