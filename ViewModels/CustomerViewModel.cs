namespace MVVMTutorial.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    using MVVMTutorial.Commands;
    using MVVMTutorial.Models;
    using MVVMTutorial.Views;
    internal class CustomerViewModel
    {
        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class.
        /// </summary>
        public CustomerViewModel()
        {
            _Customer = new Customer("Joshua");
            childViewModel = new CustomerInfoViewModel() { Info = "Instantiated in CustomerViewModel() ctor."};
            UpdateCommand = new CustomerUpdateCommand(this);
        }

        private Customer _Customer;
        private CustomerInfoViewModel childViewModel;
        /// <summary>
        /// Gets the customer instance.
        /// </summary>
        public Customer Customer
        {
            get { return _Customer; }
        }

        /// <summary>
        /// Gets the UpdatedCommand for the ViewModel. 
        /// </summary>
        public ICommand UpdateCommand
        {
            get;
            private set;
        }


        /// <summary>
        /// Saves changes made to the Customer instance.
        /// </summary>
        public void SaveChanges()
        {
            //Debug.Assert(false, String.Format("{0} was updated.", Customer.Name));

            CustomerInfoView view = new CustomerInfoView();
            view.DataContext = childViewModel;

            //childViewModel.Info = Customer.Name + " was updaed in the Database.";

            view.ShowDialog();
        }
    }
}
