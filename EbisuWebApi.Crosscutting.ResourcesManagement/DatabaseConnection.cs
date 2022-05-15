namespace EbisuWebApi.Crosscutting.ResourcesManagement
{
    public class DatabaseConnection
    {
        public static string DatabaseConnectionString()
        {
            return $"Server={Environment.GetEnvironmentVariable("HOST")};" +
                            $"Database={Environment.GetEnvironmentVariable("DATABASE")};" +
                            $"Uid={Environment.GetEnvironmentVariable("USER_NAME")};" +
                            $"Pwd={Environment.GetEnvironmentVariable("PASSWORD_DB")};";
        }

        public static string DatabaseTestConnectionString()
        {
            return $"Server={Environment.GetEnvironmentVariable("HOST")};" +
                            $"Database={Environment.GetEnvironmentVariable("DATABASE_TEST")};" +
                            $"Uid={Environment.GetEnvironmentVariable("USER_NAME")};" +
                            $"Pwd={Environment.GetEnvironmentVariable("PASSWORD_DB")};";
        }


    }
}