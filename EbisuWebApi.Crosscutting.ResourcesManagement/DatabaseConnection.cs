namespace EbisuWebApi.Crosscutting.ResourcesManagement
{
    public class DatabaseConnection
    {
        public static readonly string ConnectionString =
           $"Server={Environment.GetEnvironmentVariable("HOST")};" +
                            $"Database={Environment.GetEnvironmentVariable("DATABASE")};" +
                            $"Uid={Environment.GetEnvironmentVariable("USER_NAME")};" +
                            $"Pwd={Environment.GetEnvironmentVariable("PASSWORD")};";

    }
}