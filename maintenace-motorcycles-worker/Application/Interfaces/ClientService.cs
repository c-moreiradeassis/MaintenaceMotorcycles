using Domain.Models;

namespace Application.Interfaces
{
    public interface ClientService
    {
        Task<IEnumerable<Client>> GetEmails();
    }
}
