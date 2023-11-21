using Application.Interface;
using Data.Entity.Context;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repository;

namespace Application.Service
{
    public sealed class MaintenanceServiceImp : MaintenanceService
    {
        private readonly DatabaseContext<MaintenanceEntity> _context;
        private readonly MaintenanceRepository _repository;

        public MaintenanceServiceImp(DatabaseContext<MaintenanceEntity> context, MaintenanceRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<MaintenanceEntity> AddMaintenance(MaintenanceEntity maintenance)
        {
            _context.Add(maintenance);

            await _context.SaveChangesAsync();

            return maintenance;
        }

        public async Task<IEnumerable<Maintenance>> GetAll()
        {
            IEnumerable<Maintenance> result;

            result = await _repository.GetAll();

            if (!result.Any())
                throw new NotFoundException("There are no maintenances on database.");

                return result;
        }

        public async Task<Maintenance?> GetById(int id)
        {
            Maintenance? result;

            result = await _repository.GetById(id);

            if (result is null)
                throw new NotFoundException("This maintenance was not found on database.");

            return result;
        }

        public async Task<MaintenanceEntity?> RemoveMaintenance(int id)
        {
            var maintenanceToRemove = _context.GetById(x => x.Id == id).FirstOrDefault();

            if (maintenanceToRemove == null)
                throw new NotFoundException("It was not possible to remove this maintenance from database.");

            _context.Remove(maintenanceToRemove);

            await _context.SaveChangesAsync();

            return maintenanceToRemove;
        }

        public async Task<MaintenanceEntity?> UpdateMaintenance(int id, MaintenanceEntity maintenanceUpdated)
        {
            var maintenanceToUpdate = _context.GetById(x => x.Id == id).FirstOrDefault();

            if (maintenanceToUpdate == null)
                throw new NotFoundException("It was not possible to update this maintenance from database.");

            maintenanceToUpdate.Item = maintenanceUpdated.Item;
            maintenanceToUpdate.Operation = maintenanceUpdated.Operation;
            maintenanceToUpdate.Every = maintenanceUpdated.Every;

            _context.Update(maintenanceToUpdate);

            await _context.SaveChangesAsync();

            return maintenanceToUpdate;
        }
    }
}
