using Microsoft.Data.SqlClient;

namespace IT_STEP
{
    public static class Database
    {
        private static readonly string connectionString =
            @"Server=ALEKSEY\IT_STEP;
            Database=LibraryDb;
            Trusted_Connection=True;
            TrustServerCertificate=True;";

        public static void Initialize()
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string createTableSql = @"
                IF OBJECT_ID('Books') IS NULL
                CREATE TABLE Books (
                    Id INT IDENTITY PRIMARY KEY,
                    Title NVARCHAR(100),
                    Author NVARCHAR(100),
                    Year INT
                )";

            new SqlCommand(createTableSql, connection).ExecuteNonQuery();

            string insertSql = @"
                IF NOT EXISTS (SELECT 1 FROM Books)
                INSERT INTO Books (Title, Author, Year) VALUES
                ('1984', 'George Orwell', 1949),
                ('Animal Farm', 'George Orwell', 1945),
                ('The Hobbit', 'J.R.R. Tolkien', 1937)";

            new SqlCommand(insertSql, connection).ExecuteNonQuery();
        }

        public static List<Book> FindBooksByAuthor(string author)
        {
            var result = new List<Book>();

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT Title, Author, Year FROM Books WHERE Author = @author";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@author", author);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Book
                {
                    Title = reader.GetString(0),
                    Author = reader.GetString(1),
                    Year = reader.GetInt32(2)
                });
            }

            return result;
        }
    }
}
