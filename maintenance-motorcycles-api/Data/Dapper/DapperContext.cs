using Domain.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Data.Dapper
{
    public sealed class DapperContext
    {
        private readonly ConnectionStringsOptions _connecionStringsOptions;

        public DapperContext(IOptions<ConnectionStringsOptions> connecionStringsOptions)
        {
            _connecionStringsOptions = connecionStringsOptions.Value;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connecionStringsOptions.DefaultConnection);
    }
}
