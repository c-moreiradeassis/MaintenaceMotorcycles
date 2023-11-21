using Domain.Models;

namespace Application.Interfaces
{
    public interface MaintenanceService
    {
        Task<IEnumerable<Maintenance>> GetAll();
        Task<IEnumerable<Maintenance>> GetMaintenancesByClient(int idClient, DateTime lastMaintenance);
        DateTime GetNextMaintenanceDate(int daysToAddDate);
    }
}
