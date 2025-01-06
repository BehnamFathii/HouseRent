using HouseRent.Core.ApplicationServices.Contracts;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HouseRent.Infra.Data.Sql.Commands.ConnectionFactory;
internal class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory
{
    private readonly string _connectionString = connectionString;

    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}
