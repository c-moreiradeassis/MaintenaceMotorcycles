using Application.Interfaces;
using Domain.Models;
using Domain.Repository;

namespace Application.Services
{
    public sealed class ClientServiceImp : ClientService
    {
        private ClientRepository _repository;

        public ClientServiceImp(ClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Client>> GetEmails()
        {
            IEnumerable<Client> emails = new List<Client>();

            emails = await _repository.GetEmails();

            return emails;
        }
    }
}
