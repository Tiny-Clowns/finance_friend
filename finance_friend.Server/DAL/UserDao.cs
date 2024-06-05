using MySql.Data.MySqlClient;

namespace finance_friend.Server.DAL
{
    public class UserDao
    {
        private readonly string _connectionString;
        public UserDao(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Main")!;
        }

        private const string query_TestDBConnection = @"
select *
from User
";
        public async Task TestDBConnection()
        {
            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
