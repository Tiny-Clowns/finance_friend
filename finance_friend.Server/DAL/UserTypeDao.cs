using finance_friend.Server.Models;
using MySql.Data.MySqlClient;

namespace finance_friend.Server.DAL
{
    public class UserTypeDao
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;
        public UserTypeDao(IConfiguration config, ILogger<UserTypeDao> logger)
        {
            _connectionString = config.GetConnectionString("Main")!;
            _logger = logger;
        }

        private const string query_GetUserTypes = @"
select
ut.UserTypeId
,ut.Description
from usertype ut
";
        public async Task<IEnumerable<UserType>> GetUserTypes()
        {
            var userTypes = new List<UserType>();

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_GetUserTypes, connection);
                var dr = await command.ExecuteReaderAsync();

                while (dr.Read())
                {
                    var i = -1;

                    userTypes.Add(new UserType
                    {
                        UserTypeId = dr.GetInt32(++i),
                        Description = dr.GetString(++i),
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return userTypes;
        }

        private const string query_CreateUserType = @"
insert into usertype
(Description)
values
(@pDescription)
";
        public async Task<bool> CreateUserType(UserType userType)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_CreateUserType, connection);

                command.Parameters.Add(new MySqlParameter("@pDescription", userType.Description));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_UpdateUserType = @"
update usertype
set Description = @pDescription
where UserTypeId = @pUserTypeId
";
        public async Task<bool> UpdateUserType(UserType userType)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_UpdateUserType, connection);

                command.Parameters.Add(new MySqlParameter("@pDescription", userType.Description));
                command.Parameters.Add(new MySqlParameter("@pUserTypeId", userType.UserTypeId));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_DeleteUserType = @"
delete usertype
where UserTypeId = @pUserTypeId
";
        public async Task<bool> DeleteUserType(int userTypeId)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_DeleteUserType, connection);

                command.Parameters.Add(new MySqlParameter("@pUserTypeId", userTypeId));

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
