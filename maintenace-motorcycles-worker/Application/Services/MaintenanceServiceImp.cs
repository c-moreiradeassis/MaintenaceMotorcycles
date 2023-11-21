using Application.Interfaces;
using Domain.Models;
using Domain.Repository;

namespace Application.Services
{
    public sealed class MaintenanceServiceImp : MaintenanceService
    {
        private readonly MaintenanceRepository _repository;

        public MaintenanceServiceImp(MaintenanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Maintenance>> GetAll()
        {
            IEnumerable<Maintenance> result;

            result = await _repository.GetAll();

            return result;
        }

        public async Task<IEnumerable<Maintenance>> GetMaintenancesByClient(int idClient, DateTime lastMaintenance)
        {
            var maintenances = await _repository.GetMaintenancesByClient(idClient, lastMaintenance);

            return maintenances;
        }

        public DateTime GetNextMaintenanceDate(int daysToAddDate)
        {
            var nextMaintenanceDate = Maintenance.GetNextMaintenanceDate(daysToAddDate);

            return nextMaintenanceDate;
        }
    }
}
