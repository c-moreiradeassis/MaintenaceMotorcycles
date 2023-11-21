using Data.Entity.Context;
using Domain.Models;

namespace Application.Interface
{
    public interface MaintenanceService
    {
        Task<MaintenanceEntity> AddMaintenance(MaintenanceEntity maintenanceUpdated);
        Task<IEnumerable<Maintenance>> GetAll();
        Task<Maintenance?> GetById(int id);
        Task<MaintenanceEntity?> RemoveMaintenance(int id);
        Task<MaintenanceEntity?> UpdateMaintenance(int id, MaintenanceEntity maintenance);
    }
}
