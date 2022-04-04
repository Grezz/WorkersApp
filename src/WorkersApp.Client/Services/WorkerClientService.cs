using ApplicationCore.Entities;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersApp.Common;

namespace WorkersApp.Client.Services
{
    public class WorkerClientService
    {
        public bool ClientChanneAvailable { get {  _channel.ConnectAsync(); return _channel.State == ChannelState.Ready; } }
        private readonly WorkerStream.WorkerStreamClient _client;
        private readonly Channel _channel;
        public WorkerClientService()
        {
            _channel = new Channel("localhost", 5000, ChannelCredentials.Insecure);
            _client = new WorkerStream.WorkerStreamClient(_channel);
        }

        public async Task<IEnumerable<Worker>> GetWorkersList()
        {
            var response = await _client.GetListWorkersGrpcAsync(new WorkersListRequestGrpc());

            var itemsTransformed = response.WorkersList
               .Select(item => new Worker
               {
                   Id = item.Id,
                   Firstname = item.Firstname,
                   Secondname = item.Secondname,
                   Middlename = item.Middlename,
                   Birthday = item.Birthday.ToDateTime(),
                   IsMan = item.IsMan,
                   Childrens = item.Childrens
               })
               .ToList();
            return itemsTransformed;
        }
        public async Task AddWorker(Worker worker)
        {
            AddingWorkerGrpc workerGrpc = new AddingWorkerGrpc()
            {
                Firstname = worker.Firstname ?? "",
                Secondname = worker.Secondname ?? "",
                Middlename = worker.Middlename ?? "",
                Birthday = Timestamp.FromDateTime(DateTime.SpecifyKind(worker.Birthday, DateTimeKind.Utc)),
                IsMan = worker.IsMan,
                Childrens = worker.Childrens
            };
            await _client.AddWorkerGrpcAsync(workerGrpc);
        }

        public async Task EditWorker(Worker worker)
        {
            WorkerGrpc workerGrpc = new WorkerGrpc()
            {
                Id = worker.Id,
                Firstname = worker.Firstname ?? "",
                Secondname = worker.Secondname ?? "",
                Middlename = worker.Middlename ?? "",
                Birthday = Timestamp.FromDateTime(DateTime.SpecifyKind(worker.Birthday, DateTimeKind.Utc)),
                IsMan = worker.IsMan,
                Childrens = worker.Childrens
            };
            await _client.EditWorkerGrpcAsync(workerGrpc);
        }

        public void DeleteWorker(Worker worker)
        {
            WorkerIDGrpc workerIDGrpc = new WorkerIDGrpc() { Id = worker.Id };
            _client.DeleteWorkerGrpc(workerIDGrpc);
        }
    }
}
