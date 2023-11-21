using Domain.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Data.Dapper
{
    public sealed class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly ConnectionStringsOptions _connectionStringsOptions;

        public DapperContext(IConfiguration configuration, IOptions<ConnectionStringsOptions> connectionStringsOptions)
        {
            _configuration = configuration;
            _connectionStringsOptions = connectionStringsOptions.Value;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionStringsOptions.DefaultConnection);
    }
}
