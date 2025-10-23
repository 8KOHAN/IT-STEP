namespace IT_STEP
{
    struct Vector3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3D operator *(Vector3D v, double scalar)
        {
            return new Vector3D(v.X * scalar, v.Y * scalar, v.Z * scalar);
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public override string ToString()
        {
            return $"( X = {X}, Y = {Y}, Z = {Z})";
        }
    }

    class Program
    {
        static void Main()
        {
            Vector3D v1 = new Vector3D(3, 4, 5);
            Vector3D v2 = new Vector3D(1, 2, 3);

            Vector3D sum = v1 + v2;
            Vector3D diff = v1 - v2;
            Vector3D scaled = v1 * 2;

            Console.WriteLine($"v1 + v2 = {sum}");
            Console.WriteLine($"v1 - v2 = {diff}");
            Console.WriteLine($"v1 * 2 = {scaled}");
        }
    }
}
