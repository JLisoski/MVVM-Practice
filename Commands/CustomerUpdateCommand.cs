namespace MVVMTutorial.Commands
{
    using System.Windows.Input;
    using MVVMTutorial.ViewModels;

    internal class CustomerUpdateCommand : ICommand
    {
        /// <summary>
        /// Initialize a new instance of the CustomerUpdateCommand Class.
        /// </summary>
        public CustomerUpdateCommand(CustomerViewModel viewModel)
        {
            _ViewModel = viewModel;
        }

        private CustomerViewModel _ViewModel;

        #region ICommand Members

        public event System.EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;}
        }

        public bool CanExecute(object paramater)
        {
            return _ViewModel.CanUpdate;
        }

        public void Execute(object paramater)
        {
            _ViewModel.SaveChanges();
        }

        #endregion
    }
}
