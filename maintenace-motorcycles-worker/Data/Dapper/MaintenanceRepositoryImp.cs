using Dapper;
using Domain.Models;
using Domain.Repository;
using System.Data.SqlClient;

namespace Data.Dapper
{
    public sealed class MaintenanceRepositoryImp : MaintenanceRepository
    {
        private readonly DapperContext _dapperContext;

        public MaintenanceRepositoryImp(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Maintenance>> GetAll()
        {
            IEnumerable<Maintenance> result = new List<Maintenance>();

            var query = $@"SELECT ID {nameof(Maintenance.Id)},
                                  ITEM {nameof(Maintenance.Item)},
                                  OPERATION {nameof(Maintenance.Operation)},
                                  EVERY {nameof(Maintenance.Every)},
                                  LAST_MAINTENANCE {nameof(Maintenance.LastMaintenance)}
                             FROM MAINTENANCE";

            using (var sqlConnection = _dapperContext.CreateConnection())
            {
                result = await sqlConnection.QueryAsync<Maintenance>(query);
            }

            return result;
        }

        public async Task<IEnumerable<Maintenance>> GetMaintenancesByClient(int idClient, DateTime lastMaintenance)
        {
            IEnumerable<Maintenance> maintenances = new List<Maintenance>();

            var query = $@"SELECT M.ITEM {nameof(Maintenance.Item)},
                                  M.OPERATION {nameof(Maintenance.Operation)},
                                  C.LAST_MAINTENANCE {nameof(Maintenance.LastMaintenance)}
                             FROM CLIENT_MAINTENANCE C
                       INNER JOIN MAINTENANCE M ON C.ID_MAINTENANCE = M.ID
                            WHERE ID_CLIENT = @idClient
                              AND C.LAST_MAINTENANCE = @lastMaintenance";

            using (var sqlConnection = _dapperContext.CreateConnection())
            {
                maintenances = await sqlConnection.QueryAsync<Maintenance>(
                    query,
                    new { idClient, lastMaintenance });
            }

            return maintenances;
        }
    }
}
