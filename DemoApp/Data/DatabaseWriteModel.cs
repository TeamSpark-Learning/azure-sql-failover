using System;
using System.Data.SqlClient;
using Dapper;
using DemoApp.Data.Model;

namespace DemoApp.Data
{
    public class DatabaseWriteModel : DatabaseBaseModel
    {
        public void AddAddress(Address address)
        {
            var sql = "INSERT INTO [SalesLT].[Address] (" +
                          "AddressLine1," +
                          "City," +
                          "StateProvince," +
                          "CountryRegion," +
                          "PostalCode," +
                          "rowguid," +
                          "ModifiedDate) " +
                      "VALUES (" +
                          "@AddressLine1," +
                          "@City," +
                          "@StateProvince," +
                          "@CountryRegion," +
                          "@PostalCode," +
                          "@rowguid," +
                          "@ModifiedDate)";
            
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, address);
            }
        }

        public void DeleteAddresses()
        {
            var sql = "DELETE FROM [SalesLT].[Address] WHERE ModifiedDate >= @ModifiedDate";
            
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, new { ModifiedDate = new DateTime(2018, 1, 1) });
            }
        }
    }
}