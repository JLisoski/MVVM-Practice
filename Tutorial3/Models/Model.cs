namespace MVVMTutorial3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;

    class Model : IDataErrorInfo, INotifyPropertyChanged
    {
        private string customerName;

        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        #endregion

        #region Validation

        static readonly string[] ValidatedProperties =
{
            "CustomerName"
        };

        public bool IsValid
        {
            get
            {
                foreach(string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        string GetValidationError(String propertyName)
        {
            string error = null;

            switch (propertyName)
            {
                case "CustomerName":
                    error = ValidateCustomerName();
                    break;
            }

            return error;
        }
        private string ValidateCustomerName()
        {
            if (String.IsNullOrWhiteSpace(CustomerName))
            {
                return "Customer name cannot be empty.";
            }

            return null;
        }

        #endregion
    }
}
