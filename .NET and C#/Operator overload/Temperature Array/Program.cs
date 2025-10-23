namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            TemperatureArray weekTemperatures = new TemperatureArray();

            weekTemperatures[0] = 15.5;
            weekTemperatures[1] = 17.2;
            weekTemperatures[2] = 18.0;
            weekTemperatures[3] = 16.4;
            weekTemperatures[4] = 14.8;
            weekTemperatures[5] = 19.3;
            weekTemperatures[6] = 20.1;

            Console.WriteLine($"Average weekly temperature: {weekTemperatures.GetAverageTemperature():F2}°C");
        }
    }
}
