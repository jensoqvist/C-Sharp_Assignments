using CustomerRegistry.Data.CustomerData;
using CustomerRegistry.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CustomerRegistry
{
    /// <summary>
    /// Main ViewModel
    /// </summary>
    public class MainViewModel :BaseViewModel
    {

        private bool newCust;
        /// <summary>
        /// ViewModels for diffrent views
        /// </summary>
        #region ViewModels
        private BaseViewModel currentViewModel;
        public BaseViewModel CurrentViewModel { get => currentViewModel; set { currentViewModel = value; OnPropertyChanged(); } }

        /// <summary>
        /// Handling bindings for managerview
        /// </summary>
        private ManagerViewModel managerView = new ManagerViewModel();
        public ManagerViewModel ManagerView { get => managerView; set { managerView = value; OnPropertyChanged(); } }

        /// <summary>
        /// Handling bindings for CustomerView
        /// </summary>
        private CustomerViewModel customertView = new CustomerViewModel();
        public CustomerViewModel CustomerView { get => customertView; set { customertView = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        public ICommand Add { get; set; }
        public ICommand Edit { get; set; }
        public ICommand Back { get; set; }
        public ICommand Save { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainViewModel()
        {
            CurrentViewModel = ManagerView;
            Add = new RelayCommand(AddCommand);
            Edit = new RelayCommand(EditCommand);
            Back = new RelayCommand(BackCommand);
            Save = new RelayCommand(SaveCommand);
            
        }
        #endregion

        #region Methods
        public void SwitchToAddView()
        {
            CurrentViewModel = CustomerView;
        }

        public void SwitchToHomeView()
        {
            CurrentViewModel = ManagerView;
        }

        public void AddCommand()
        {
            newCust = true;
            int freeId = ManagerView.Manager.GetFreeId(); //first free id in list
            CustomerView.CurCustomer = new(freeId);
            SwitchToAddView();
        }

        public void EditCommand()
        {
            newCust = false;
            CustomerView.CurCustomer = ManagerView.SelectedCustomer.DeepCopy();
            SwitchToAddView();
        }
        public void BackCommand()
        {
            SwitchToHomeView();
        }
        public void SaveCommand()
        {
            if (CustomerView.ValidInput)
            {
                if(!newCust)
                    ManagerView.SaveCustomer(CustomerView.CurCustomer, ManagerView.SelectedIndex);
                else
                    ManagerView.AddCustomer(CustomerView.CurCustomer);
                SwitchToHomeView();
            }
            else
            {
                MessageBox.Show(CustomerView.ValidFields, "Error saving..."); //Error message if input isn't valid
            }
        }
        #endregion

    }
}
