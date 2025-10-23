namespace IT_STEP
{
    struct RGBColor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public RGBColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public string ToHex()
        {
            return $"#{R:X2}{G:X2}{B:X2}";
        }

        public (double H, double S, double L) ToHSL()
        {
            double r = R / 255.0;
            double g = G / 255.0;
            double b = B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double h = 0, s, l = (max + min) / 2;

            if (max == min)
            {
                h = s = 0;
            }
            else
            {
                double d = max - min;
                s = l > 0.5 ? d / (2 - max - min) : d / (max + min);

                if (max == r)
                    h = (g - b) / d + (g < b ? 6 : 0);
                else if (max == g)
                    h = (b - r) / d + 2;
                else
                    h = (r - g) / d + 4;

                h *= 60;
            }

            return (Math.Round(h, 1), Math.Round(s * 100, 1), Math.Round(l * 100, 1));
        }

        public (double C, double M, double Y, double K) ToCMYK()
        {
            double r = R / 255.0;
            double g = G / 255.0;
            double b = B / 255.0;

            double k = 1 - Math.Max(r, Math.Max(g, b));
            double c = (1 - r - k) / (1 - k);
            double m = (1 - g - k) / (1 - k);
            double y = (1 - b - k) / (1 - k);

            if (k == 1) c = m = y = 0;

            return (Math.Round(c * 100, 1), Math.Round(m * 100, 1), Math.Round(y * 100, 1), Math.Round(k * 100, 1));
        }

        public override string ToString()
        {
            return $"RGB({R}, {G}, {B})";
        }
    }

    class Program
    {
        static void Main()
        {
            RGBColor color = new RGBColor(255, 128, 64);

            Console.WriteLine($"Color: {color}");
            Console.WriteLine($"HEX: {color.ToHex()}");

            var (h, s, l) = color.ToHSL();
            Console.WriteLine($"HSL: H={h}°, S={s}%, L={l}%");

            var (c, m, y, k) = color.ToCMYK();
            Console.WriteLine($"CMYK: C={c}%, M={m}%, Y={y}%, K={k}%");
        }
    }
}
