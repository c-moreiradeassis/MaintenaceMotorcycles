using Domain.Models;

namespace Domain.Repository
{
    public interface MaintenanceRepository
    {
        Task<IEnumerable<Maintenance>> GetAll();
        Task<IEnumerable<Maintenance>> GetMaintenancesByClient(int idClient, DateTime lastMaintenance);
    }
}
