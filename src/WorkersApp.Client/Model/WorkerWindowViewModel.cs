using ApplicationCore.Entities;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WorkersApp.Client.Model
{
    public class BoolInverterConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                return !(bool)value;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                return !(bool)value;
            }
            return value;
        }

        #endregion
    }
    class WorkerWindowViewModel : BindableBase
    {
        public int Id { get; set; }
        public String Firstname { get; set; }
        public String Secondname { get; set; }
        public String Middlename { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsMan { get; set; }
        public int Childrens { get; set; }

        public WorkerWindowViewModel(Worker worker)
        {
            Id = worker.Id;
            Firstname = worker.Firstname;
            Secondname = worker.Secondname;
            Middlename = worker.Middlename;
            Birthday = worker.Birthday;
            IsMan = worker.IsMan;
            Childrens = worker.Childrens;
        }

        public Worker ViewModelWorker
        {
            get
            {
                return new Worker()
                {
                    Id = this.Id,
                    Firstname = this.Firstname,
                    Secondname = this.Secondname,
                    Middlename = this.Middlename,
                    Birthday = this.Birthday,
                    IsMan = this.IsMan,
                    Childrens = this.Childrens
                };
            }
        }
    }
}
