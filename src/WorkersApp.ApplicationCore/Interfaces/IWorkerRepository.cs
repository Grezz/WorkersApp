using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IWorkerRepository
    {
        Task<List<Worker>> ListAllWorkersAsync();
        Task<int> UpdateAsync(Worker entity);
        Task<int> AddAsync(Worker entity);
        Task DeleteAsync(Worker entity);
        Task<Worker> GetWorkerByIdAsync(int id);
    }
}
