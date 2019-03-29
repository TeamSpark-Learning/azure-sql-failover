using System.Data.SqlClient;
using Dapper;

namespace DemoApp.Data
{
    public class DatabaseReadModel : DatabaseBaseModel
    {
        public int GetAddressesCount()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("SELECT COUNT(*) FROM [SalesLT].[Address]");
            }
        }
    }
}