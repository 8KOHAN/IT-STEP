namespace IT_STEP
{
    public class Program
    {
        public delegate (int R, int G, int B) RainbowColorDelegate(string colorName);

        public static void Main()
        {
            RainbowColorDelegate getRgb = delegate (string color)
            {
                switch (color.ToLower())
                {
                    case "red": return (255, 0, 0);
                    case "orange": return (255, 165, 0);
                    case "yellow": return (255, 255, 0);
                    case "green": return (0, 128, 0);
                    case "blue": return (0, 0, 255);
                    case "violet": return (238, 130, 238);
                    default: return (0, 0, 0);
                }
            };

            string[] colors = { "red", "orange", "yellow", "green", "blue", "violet" };

            foreach (var color in colors)
            {
                var rgb = getRgb(color);
                Console.WriteLine($"{color}: RGB({rgb.R}, {rgb.G}, {rgb.B})");
            }
        }
    }
}
