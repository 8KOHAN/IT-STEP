using Dapper;
using Microsoft.Data.SqlClient;

namespace IT_STEP
{
    public class DogRepository
    {
        private string connectionString = "Data Source = ALEKSEY\\IT_STEP;Database=DogShelterDb;Integrated Security = True; Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name =\"SQL Server Management Studio\";Command Timeout=0";
        
        public void AddDog(Dog dog)
        {
            using var connection = new SqlConnection(connectionString);
            string sql = "INSERT INTO Dogs (Name, Age, Breed) VALUES (@Name, @Age, @Breed)";
            connection.Execute(sql, dog);
        }

        public IEnumerable<Dog> GetAllDogs()
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Query<Dog>("SELECT * FROM Dogs");
        }

        public IEnumerable<Dog> GetAvailableDogs()
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Query<Dog>("SELECT * FROM Dogs WHERE IsAdopted = 0");
        }

        public IEnumerable<Dog> GetAdoptedDogs()
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Query<Dog>("SELECT * FROM Dogs WHERE IsAdopted = 1");
        }

        public Dog GetDogById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            return connection.QueryFirstOrDefault<Dog>(
                "SELECT * FROM Dogs WHERE Id = @Id", new { Id = id });
        }

        public IEnumerable<Dog> SearchByName(string name)
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Query<Dog>(
                "SELECT * FROM Dogs WHERE Name LIKE @Name",
                new { Name = $"%{name}%" });
        }

        public IEnumerable<Dog> SearchByBreed(string breed)
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Query<Dog>(
                "SELECT * FROM Dogs WHERE Breed LIKE @Breed",
                new { Breed = $"%{breed}%" });
        }
        

        public void UpdateDog(Dog dog)
        {
            using var connection = new SqlConnection(connectionString);
            string sql = @"UPDATE Dogs
                       SET Name = @Name,
                           Age = @Age,
                           Breed = @Breed,
                           IsAdopted = @IsAdopted
                       WHERE Id = @Id";
            connection.Execute(sql, dog);
        }
    }
}
