using ApplicationCore.Entities;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using WorkersApp.Client.Services;

namespace WorkersApp.Client.Model
{
    class WorkerListWindowViewModel : BindableBase
    {
        private readonly WorkerClientService _workerClient = new WorkerClientService();
        private DispatcherTimer _timer = new DispatcherTimer();

        public ObservableCollection<Worker> WorkersList { get; } = new ObservableCollection<Worker>();
        private readonly object _workersListLockObject = new object();

        public WorkerListWindowViewModel()
        {
            BindingOperations.EnableCollectionSynchronization(WorkersList, _workersListLockObject);
            if (_workerClient.ClientChanneAvailable)
            {
                ReLoadWorkers();
            }
            else
            {
                MessageBox.Show("Сервер недоступен, по пробуйте позже.");

                _timer = new DispatcherTimer();
                _timer.Tick += new EventHandler(ReloadWorkersByTimer);
                _timer.Interval = new TimeSpan(0, 0, 3);
                _timer.Start();
            }
        }

        private void ReloadWorkersByTimer(object o, EventArgs args)
        {
            if (_workerClient.ClientChanneAvailable)
            {
                ReLoadWorkers();
                _timer.Stop();
            }
        }

        private async void ReLoadWorkers()
        {
            WorkersList.Clear();
            List<Worker> responseWorkersList = (await _workerClient.GetWorkersList()).ToList();
            foreach (var w in responseWorkersList)
            {
                WorkersList.Add(w);
            }
        }

        public async void AddWorker(Worker worker)
        {
            try
            {
                await _workerClient.AddWorker(worker);
                ReLoadWorkers();
            }
            catch
            {
                if (!_workerClient.ClientChanneAvailable)
                {
                    MessageBox.Show("Сервер недоступен, по пробуйте позже.");
                }
                else
                {
                    throw;
                }
            }
        }

        public async void EditWorker(Worker worker)
        {
            try
            {
                await _workerClient.EditWorker(worker);
                ReLoadWorkers();
            }
            catch
            {
                if (!_workerClient.ClientChanneAvailable)
                {
                    MessageBox.Show("Сервер недоступен, по пробуйте позже.");
                }
                else
                {
                    throw;
                }
            }
        }

        public void DeleteWorker(Worker worker)
        {
            try
            {
                _workerClient.DeleteWorker(worker);
                ReLoadWorkers();
            }
            catch
            {
                if (!_workerClient.ClientChanneAvailable)
                {
                    MessageBox.Show("Сервер недоступен, по пробуйте позже.");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
