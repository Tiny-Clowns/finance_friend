using System.Data.Common;
using MySql.Data.MySqlClient;

namespace finance_friend.Server.Utils
{
    public static class DBDataReaderExtensions
    {
        public static T Get<T>(this DbDataReader dr, int colIndex)
        {
            if (!dr.IsDBNull(colIndex))
            {
                return dr.GetFieldValue<T>(colIndex);
            }
            return default!;
        }
    }
}
