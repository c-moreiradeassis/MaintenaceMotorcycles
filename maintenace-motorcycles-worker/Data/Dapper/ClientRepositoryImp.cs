using Dapper;
using Domain.Configuration;
using Domain.Models;
using Domain.Repository;

namespace Data.Dapper
{
    public sealed class ClientRepositoryImp : ClientRepository
    {
        private readonly DapperContext _dapperContext;

        public ClientRepositoryImp(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Client>> GetEmails()
        {
            IEnumerable<Client> clients = new List<Client>();

            var query = $@"SELECT ID {nameof(Client.Id)},
                                  EMAIL {nameof(Client.Email)}
                             FROM CLIENT";

            using (var sqlConnection = _dapperContext.CreateConnection())
            {
                clients = await sqlConnection.QueryAsync<Client>(query);
            }

            return clients;
        }
    }
}
