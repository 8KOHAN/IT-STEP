import json
from random import uniform
from typing import Protocol, runtime_checkable
from urllib.error import URLError
from urllib.request import urlopen


@runtime_checkable
class TemperatureSensor(Protocol):
    def read_temperature(self) -> float:
        ...

    def get_sensor_id(self) -> str:
        ...


class WeatherAPISensor:
    SENSOR_ID = "WAS26-Odesa"
    API_URL = (
        "https://api.open-meteo.com/v1/forecast"
        "?latitude=46.4825&longitude=30.7233"
        "&current=temperature_2m"
    )

    def read_temperature(self) -> float:
        try:
            with urlopen(self.API_URL, timeout=10) as response:
                data = json.load(response)

            return float(data["current"]["temperature_2m"])
        except (
            URLError,
            TimeoutError,
            OSError,
            ValueError,
            KeyError,
            TypeError,
        ) as error:
            raise RuntimeError(
                "Failed to retrieve the temperature in Odesa."
            ) from error

    def get_sensor_id(self) -> str:
        return self.SENSOR_ID


class SimulatedSensor:
    def __init__(self, base: float, deviation: float) -> None:
        if deviation < 0:
            raise ValueError("Deviation cannot be negative.")

        self.base = base
        self.deviation = deviation

    def read_temperature(self) -> float:
        return self.base + uniform(-self.deviation, self.deviation)

    def get_sensor_id(self) -> str:
        return "Simulated-Sensor"


class FakeAlways25:
    def read_temperature(self) -> float:
        return 25.0

    def get_sensor_id(self) -> str:
        return "Fake-25"


def main() -> None:
    sensors: list[TemperatureSensor] = [
        WeatherAPISensor(),
        SimulatedSensor(base=20.0, deviation=3.0),
        FakeAlways25(),
    ]

    for sensor in sensors:
        print(f"Sensor ID: {sensor.get_sensor_id()}")

        try:
            temperature = sensor.read_temperature()
            print(f"Temperature: {temperature:.2f} °C")
        except RuntimeError as error:
            print(f"Error: {error}")

        print(
            "Implements protocol:",
            isinstance(sensor, TemperatureSensor),
        )
        print()


if __name__ == "__main__":
    main()
