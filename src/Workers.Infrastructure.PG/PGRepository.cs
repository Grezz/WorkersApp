using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersApp.Infrastructure.PG
{
    public class PGRepository : IWorkerRepository
    {
        protected readonly PGContext _dbContext;
        public PGRepository(PGContext dbCondext)
        {
            _dbContext = dbCondext;
        }

        public async Task<int> AddAsync(Worker entity)
        {
            var addedEntity =  await _dbContext.Workers.AddAsync(entity);
            await _dbContext.SaveChangesAsync(default);
            return addedEntity.Entity.Id;
        }

        public async Task DeleteAsync(Worker entity)
        {
            _dbContext.Workers.Remove(entity);
            await _dbContext.SaveChangesAsync(default);
        }

        public async Task<List<Worker>> ListAllWorkersAsync()
        {
            return await _dbContext.Workers.ToListAsync();
        }

        public async Task<int> UpdateAsync(Worker entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(default);
            return entity.Id;
        }

        public async Task<Worker> GetWorkerByIdAsync(int id)
        {
            return await _dbContext.Workers.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
