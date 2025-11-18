namespace IT_STEP
{
    public class Program
    {
        static void Main()
        {
            Action showTime = () => Console.WriteLine("Current time: " + DateTime.Now.ToLongTimeString());
            Action showDate = () => Console.WriteLine("Current date: " + DateTime.Now.ToShortDateString());
            Action showDayOfWeek = () => Console.WriteLine("Day of week: " + DateTime.Now.DayOfWeek);

            Func<double, double, double> triangleArea = (b, h) => (b * h) / 2;
            Func<double, double, double> rectangleArea = (w, h) => w * h;

            Predicate<double> isLargeArea = area => area > 50;


            showTime();
            showDate();
            showDayOfWeek();

            double tri = triangleArea(10, 8);
            double rect = rectangleArea(7, 5);

            Console.WriteLine($"Triangle area: {tri}");
            Console.WriteLine($"Rectangle area: {rect}");

            Console.WriteLine("Is triangle area > 50? " + isLargeArea(tri));
            Console.WriteLine("Is rectangle area > 50? " + isLargeArea(rect));
        }
    }
}
