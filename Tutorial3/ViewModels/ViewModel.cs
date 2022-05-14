namespace MVVMTutorial3.ViewModels
{
    using MVVMTutorial3.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    internal class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Model = new Model()
            {
                CustomerName = "Joshua"
            };
        }
        public Model Model
        {
            get;
            set;
        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
