using finance_friend.Server.Models;
using MySql.Data.MySqlClient;

namespace finance_friend.Server.DAL
{
    public class AddressDao
    {
        private readonly string _connectionString;
        public AddressDao(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Main")!;
        }

        private const string query_TestDBConnection = @"
select *
from Address
";
        public async Task<IEnumerable<Address>> GetAddresses()
        {
            var addresses = new List<Address>();

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_TestDBConnection, connection);
                var dr = await command.ExecuteReaderAsync();

                while (dr.Read())
                {
                    addresses.Add(new Address(dr));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return addresses;
        }
    }
}
