using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkersApp.Client.Model;

namespace WorkersApp.Client.View
{
    /// <summary>
    /// Логика взаимодействия для WorkerListWindow.xaml
    /// </summary>
    public partial class WorkerListWindow : Window
    {
        public WorkerListWindow()
        {
            InitializeComponent();
            DataContext = new WorkerListWindowViewModel();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            WorkerWindow WorkerWindow = new WorkerWindow();
            if (WorkerWindow.ShowDialog() == true)
            {
                (DataContext as WorkerListWindowViewModel).AddWorker(WorkerWindow.AddedOrEditWorker);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            WorkerWindow WorkerWindow = new WorkerWindow((Worker)workersList.SelectedItem);
            if (WorkerWindow.ShowDialog() == true)
            {
                (DataContext as WorkerListWindowViewModel).EditWorker(WorkerWindow.AddedOrEditWorker);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить работника?", "Удаление работника!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                (DataContext as WorkerListWindowViewModel).DeleteWorker((Worker)workersList.SelectedItem);
            }
        }
    }
}
