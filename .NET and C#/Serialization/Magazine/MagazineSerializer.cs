using System.Text.Json;

namespace IT_STEP
{
    public static class MagazineSerializer
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true  // for a beautiful result
        };

        public static string Serialize(Magazine magazine)
        {
            return JsonSerializer.Serialize(magazine, options);
        }

        public static Magazine Deserialize(string json)
        {
            return JsonSerializer.Deserialize<Magazine>(json, options);
        }

        public static void SaveToFile(string path, Magazine magazine)
        {
            File.WriteAllText(path, Serialize(magazine));
        }

        public static Magazine LoadFromFile(string path)
        {
            string json = File.ReadAllText(path);
            return Deserialize(json);
        }
    }
}
