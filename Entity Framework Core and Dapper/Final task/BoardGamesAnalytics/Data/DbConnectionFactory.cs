using Microsoft.Data.SqlClient;

namespace BoardGamesAnalytics.Data;
public static class DbConnectionFactory
{
    private const string ConnectionString =
        "Data Source=ALEKSEY\\IT_STEP;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0";

    public static SqlConnection CreateConnection()
        => new SqlConnection(ConnectionString);
}
