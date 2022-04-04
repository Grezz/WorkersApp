using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WorkersApp.Common
{
    public class WorkerStreamService : WorkerStream.WorkerStreamBase
    {
        private readonly ILogger<WorkerStreamService> _logger;
        private readonly IWorkerRepository _repository;
        public WorkerStreamService(ILogger<WorkerStreamService> logger, IWorkerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public override async Task<WorkersListResponseGrpc> GetListWorkersGrpc(WorkersListRequestGrpc request, ServerCallContext context)
        {
            List<Worker> workersList = new List<Worker>();
            workersList = await _repository.ListAllWorkersAsync();
           
            var itemsTransformed = workersList
                .Select(item => new WorkerGrpc
                    {
                        Id =  item.Id,
                        Firstname = item.Firstname,
                        Secondname = item.Secondname,
                        Middlename = item.Middlename,
                        Birthday = Timestamp.FromDateTime(DateTime.SpecifyKind(item.Birthday,DateTimeKind.Utc)),
                        IsMan = item.IsMan,
                        Childrens = item.Childrens
                    })
                .ToList();

            WorkersListResponseGrpc workerListResponse = new WorkersListResponseGrpc();
            workerListResponse.WorkersList.AddRange(itemsTransformed);

            return workerListResponse;
        }

        public override async Task<WorkerIDGrpc> AddWorkerGrpc(AddingWorkerGrpc request, ServerCallContext context)
        {
            Worker worker = new Worker()
            {
                Firstname = request.Firstname,
                Secondname = request.Secondname,
                Middlename = request.Middlename,
                Birthday = request.Birthday.ToDateTime(),
                IsMan = request.IsMan,
                Childrens = request.Childrens
            };
            return new WorkerIDGrpc() { Id = (await _repository.AddAsync(worker)) };
        }

        public override async Task<WorkerIDGrpc> EditWorkerGrpc(WorkerGrpc request, ServerCallContext context)
        {
            Worker worker = new Worker()
            {
                Id = request.Id,
                Firstname = request.Firstname,
                Secondname = request.Secondname,
                Middlename = request.Middlename,
                Birthday = request.Birthday.ToDateTime(),
                IsMan = request.IsMan,
                Childrens = request.Childrens
            };
            return new WorkerIDGrpc() { Id = (await _repository.UpdateAsync(worker)) };
        }

        public override async Task<DeletingWorkerReques> DeleteWorkerGrpc(WorkerIDGrpc request, ServerCallContext context)
        {
            Worker worker = await _repository.GetWorkerByIdAsync(request.Id);
            if (worker is not null)
            {
                await _repository.DeleteAsync(worker);
            }
            return new DeletingWorkerReques();
        }
    }
}
