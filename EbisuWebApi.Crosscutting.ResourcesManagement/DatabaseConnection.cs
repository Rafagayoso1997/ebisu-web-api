namespace EbisuWebApi.Crosscutting.ResourcesManagement
{
    public class DatabaseConnection
    {
        public static string ConnectionString()
        {
            return $"Server={Environment.GetEnvironmentVariable("HOST")};" +
                            $"Database={Environment.GetEnvironmentVariable("DATABASE")};" +
                            $"Uid={Environment.GetEnvironmentVariable("USER_NAME")};" +
                            $"Pwd={Environment.GetEnvironmentVariable("PASSWORD_DB")};";
        } 
    }
}