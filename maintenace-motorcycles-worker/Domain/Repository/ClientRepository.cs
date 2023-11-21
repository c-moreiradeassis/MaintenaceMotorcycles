using Domain.Models;

namespace Domain.Repository
{
    public interface ClientRepository
    {
        Task<IEnumerable<Client>> GetEmails();
    }
}
