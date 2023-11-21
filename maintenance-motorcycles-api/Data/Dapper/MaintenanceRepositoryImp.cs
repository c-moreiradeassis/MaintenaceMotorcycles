using Dapper;
using Domain.Models;
using Domain.Repository;

namespace Data.Dapper
{
    public sealed class MaintenanceRepositoryImp : MaintenanceRepository
    {
        private readonly DapperContext _context;

        public MaintenanceRepositoryImp(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Maintenance>> GetAll()
        {
            IEnumerable<Maintenance> result = new List<Maintenance>();

            var query = $@"SELECT ID {nameof(Maintenance.Id)},
                                  ITEM {nameof(Maintenance.Item)},
                                  OPERATION {nameof(Maintenance.Operation)},
                                  EVERY {nameof(Maintenance.Every)}
                             FROM MAINTENANCE";

            using (var sqlConnection = _context.CreateConnection())
            {
                result = await sqlConnection.QueryAsync<Maintenance>(query);
            }

            return result;
        }

        public async Task<Maintenance?> GetById(int id)
        {
            Maintenance? result = new Maintenance();

            var query = $@"SELECT ID {nameof(Maintenance.Id)},
                                  ITEM {nameof(Maintenance.Item)},
                                  OPERATION {nameof(Maintenance.Operation)},
                                  EVERY {nameof(Maintenance.Every)}
                             FROM MAINTENANCE
                            WHERE ID = @id";

            using (var sqlConnection = _context.CreateConnection())
            {
                result = await sqlConnection.QueryFirstOrDefaultAsync<Maintenance>(query, new { id });
            }

            return result;
        }
    }
}
