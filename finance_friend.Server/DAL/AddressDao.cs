using System.Diagnostics.Metrics;
using finance_friend.Server.Models;
using finance_friend.Server.Utils;
using MySql.Data.MySqlClient;

namespace finance_friend.Server.DAL
{
    public class AddressDao
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;
        public AddressDao(IConfiguration config, ILogger<AddressDao> logger)
        {
            _connectionString = config.GetConnectionString("Main")!;
            _logger = logger;
        }

        private const string query_GetAddresses = @"
select
a.AddressId
,a.Address1
,a.Address2
,a.Address3
,a.City
,a.State
,a.Country
,a.Postcode
from address a
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

                var command = new MySqlCommand(query_GetAddresses, connection);
                var dr = await command.ExecuteReaderAsync();

                while (dr.Read())
                {
                    var i = -1;

                    addresses.Add(new Address
                    {
                        AddressId = dr.GetInt32(++i),
                        Address1 = dr.GetString(++i),
                        Address2 = dr.Get<string?>(++i),
                        Address3 = dr.Get<string?>(++i),
                        City = dr.GetString(++i),
                        State = dr.Get<string?>(++i),
                        Country = dr.GetString(++i),
                        PostCode = dr.GetString(++i),
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return addresses;
        }

        private const string query_CreateAddress = @"
insert into address
(
    Address1
    ,Address2
    ,Address3
    ,City
    ,State
    ,Country
    ,Postcode
)
values
(
    @pAddress1
    ,@pAddress2
    ,@pAddress3
    ,@pCity
    ,@pState
    ,@pCountry
    ,@pPostcode
)
";
        public async Task<bool> CreateAddress(Address address)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_CreateAddress, connection);

                command.Parameters.Add(new MySqlParameter("@pAddress1", address.Address1));
                command.Parameters.Add(new MySqlParameter("@pAddress2", address.Address2));
                command.Parameters.Add(new MySqlParameter("@pAddress3", address.Address3));
                command.Parameters.Add(new MySqlParameter("@pCity", address.City));
                command.Parameters.Add(new MySqlParameter("@pState", address.State));
                command.Parameters.Add(new MySqlParameter("@pCountry", address.Country));
                command.Parameters.Add(new MySqlParameter("@pPostcode", address.PostCode));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_UpdateAddress = @"
update address
set 
    Address1 = @pAddress1
    ,Address2 = @pAddress2
    ,Address3 = @pAddress3
    ,City = @pCity
    ,State = @pState
    ,Country = @pCountry
    ,Postcode = @pPostcode
where 
    AddressId = @pAddressId
";
        public async Task<bool> UpdateAddress(Address address)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_UpdateAddress, connection);

                command.Parameters.Add(new MySqlParameter("@pAddress1", address.Address1));
                command.Parameters.Add(new MySqlParameter("@pAddress2", address.Address2));
                command.Parameters.Add(new MySqlParameter("@pAddress3", address.Address3));
                command.Parameters.Add(new MySqlParameter("@pCity", address.City));
                command.Parameters.Add(new MySqlParameter("@pState", address.State));
                command.Parameters.Add(new MySqlParameter("@pCountry", address.Country));
                command.Parameters.Add(new MySqlParameter("@pPostcode", address.PostCode));
                command.Parameters.Add(new MySqlParameter("@pAddressId", address.AddressId));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_DeleteAddress = @"
delete address
where AddressId = @pAddressId
";
        public async Task<bool> DeleteAddress(int addressId)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_DeleteAddress, connection);

                command.Parameters.Add(new MySqlParameter("@pAddressId", addressId));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }
    }
}
