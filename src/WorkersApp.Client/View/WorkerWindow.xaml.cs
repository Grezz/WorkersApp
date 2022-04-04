using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddWorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public Worker AddedOrEditWorker { 
            get {
                return ((WorkerWindowViewModel )DataContext).ViewModelWorker;
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public WorkerWindow()
        {
            InitializeComponent();
            DataContext = new WorkerWindowViewModel(new Worker() { IsMan = true });
        }

        public WorkerWindow(Worker worker)
        {
            InitializeComponent();
            DataContext = new WorkerWindowViewModel(worker);
        }

        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(txtFirstName.Text))
            {
                this.DialogResult = true;
                return;
            }
            else
            {
                MessageBox.Show("Имя не может быть пустым.");
            }
            
        }
    }
}
