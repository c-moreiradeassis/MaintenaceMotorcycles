using Domain.Models;

namespace Domain.Repository
{
    public interface MaintenanceRepository
    {
        Task<IEnumerable<Maintenance>> GetAll();
        Task<Maintenance?> GetById(int id);
    }
}
