using System.ComponentModel.Design;
using finance_friend.Server.Models;
using MySql.Data.MySqlClient;

namespace finance_friend.Server.DAL
{
    public class UserDao
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;
        public UserDao(IConfiguration config, ILogger<UserDao> logger)
        {
            _connectionString = config.GetConnectionString("Main")!;
            _logger = logger;
        }

        private const string query_GetUsers = @"
select
u.UserId
,u.LastName
,u.FirstName
,u.Username
,u.BalanceUSD
,u.Email
,u.MobileNumber
,u.AddressId
,u.CompanyId
,u.UserTypeId
,u.CurrencyId
from user u
";
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = new List<User>();

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_GetUsers, connection);
                var dr = await command.ExecuteReaderAsync();

                while (dr.Read())
                {
                    var i = -1;

                    users.Add(new User
                    {
                        UserId = dr.GetInt32(++i),
                        LastName = dr.GetString(++i),
                        FirstName = dr.GetString(++i),
                        Username = dr.GetString(++i),
                        BalanceUSD = dr.GetDecimal(++i),
                        Email = dr.GetString(++i),
                        MobileNumber = dr.GetString(++i),
                        AddressId = dr.GetInt32(++i),
                        CompanyId = dr.GetFieldValue<int?>(++i),
                        UserTypeId = dr.GetInt32(++i),
                        CurrencyId = dr.GetInt32(++i),
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return users;
        }

        private const string query_CreateUser = @"
insert into user
(
    LastName
    ,FirstName
    ,Username
    ,BalanceUSD
    ,Email
    ,MobileNumber
    ,AddressId
    ,CompanyId
    ,UserTypeId
    ,CurrencyId
)
values
(
    @pLastName
    ,@pFirstName
    ,@pUsername
    ,@pBalanceUSD
    ,@pEmail
    ,@pMobileNumber
    ,@pAddressId
    ,@pCompanyId
    ,@pUserTypeId
    ,@pCurrencyId
)
";
        public async Task<bool> CreateUser(User user)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_CreateUser, connection);

                command.Parameters.Add(new MySqlParameter("@pLastName", user.LastName));
                command.Parameters.Add(new MySqlParameter("@pFirstName", user.FirstName));
                command.Parameters.Add(new MySqlParameter("@pUsername", user.Username));
                command.Parameters.Add(new MySqlParameter("@pBalanceUSD", user.BalanceUSD));
                command.Parameters.Add(new MySqlParameter("@pEmail", user.Email));
                command.Parameters.Add(new MySqlParameter("@pMobileNumber", user.MobileNumber));
                command.Parameters.Add(new MySqlParameter("@pAddressId", user.AddressId));
                command.Parameters.Add(new MySqlParameter("@pCompanyId", user.CompanyId));
                command.Parameters.Add(new MySqlParameter("@pUserTypeId", user.UserTypeId));
                command.Parameters.Add(new MySqlParameter("@pCurrencyId", user.CurrencyId));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_UpdateUser = @"
update user
set 
    LastName = @pLastName
    ,FirstName = @pFirstName
    ,Username = @pUsername
    ,BalanceUSD = @pBalanceUSD
    ,Email = @pEmail
    ,MobileNumber = @pMobileNumber
    ,AddressId = @pAddressId
    ,CompanyId = @pCompanyId
    ,UserTypeId = @pUserTypeId
    ,CurrencyId = @pCurrencyId
where 
    UserId = @pUserId
";
        public async Task<bool> UpdateUser(User user)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_UpdateUser, connection);

                command.Parameters.Add(new MySqlParameter("@pLastName", user.LastName));
                command.Parameters.Add(new MySqlParameter("@pFirstName", user.FirstName));
                command.Parameters.Add(new MySqlParameter("@pUsername", user.Username));
                command.Parameters.Add(new MySqlParameter("@pBalanceUSD", user.BalanceUSD));
                command.Parameters.Add(new MySqlParameter("@pEmail", user.Email));
                command.Parameters.Add(new MySqlParameter("@pMobileNumber", user.MobileNumber));
                command.Parameters.Add(new MySqlParameter("@pAddressId", user.AddressId));
                command.Parameters.Add(new MySqlParameter("@pCompanyId", user.CompanyId));
                command.Parameters.Add(new MySqlParameter("@pUserTypeId", user.UserTypeId));
                command.Parameters.Add(new MySqlParameter("@pCurrencyId", user.CurrencyId));
                command.Parameters.Add(new MySqlParameter("@pUserId", user.UserId));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_DeleteUser = @"
delete user
where UserId = @pUserId
";
        public async Task<bool> DeleteUser(int userId)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_DeleteUser, connection);

                command.Parameters.Add(new MySqlParameter("@pUserId", userId));

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
