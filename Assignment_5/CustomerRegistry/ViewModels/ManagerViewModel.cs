
using CustomerRegistry.Data;
using CustomerRegistry.Data.CustomerData;
using CustomerRegistry.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace CustomerRegistry.ViewModels
{
    public class ManagerViewModel : BaseViewModel
    {

        #region UserControls for view
        private UserControl side = new MainSideUC();
        public UserControl Side { get => side; set => side = value; }

        private UserControl main = new MainUC();
        public UserControl Main { get => main; set => main = value; }
        #endregion

        #region Fields
        private Manager manager = new Manager();
        private ObservableCollection<Customer> customerList ;
        private Customer selectedCustomer;
        private int selectedIndex;
        private bool enableEdit = false;
        #endregion

        #region Propertys
        /// <summary>
        /// Manager handles list of contacts
        /// </summary>
        public Manager Manager { get => manager; set { manager = value; OnPropertyChanged(); } }
        public ObservableCollection<Customer> CustomerList { get => customerList; set { customerList = value; OnPropertyChanged(); } }

        /// <summary>
        /// Property that controls if Edit button is enabled
        /// </summary>
        public bool EnableEdit { get => enableEdit; set { enableEdit = value; OnPropertyChanged(); } }
        /// <summary>
        /// Selected customer in list
        /// </summary>
        public Customer SelectedCustomer { get => selectedCustomer; set { selectedCustomer = value; if (value != null) EnableEdit = true; else EnableEdit = false; OnPropertyChanged(); } }
        public int SelectedIndex { get => selectedIndex; set { selectedIndex = value; OnPropertyChanged(); } }
        #endregion


        #region Commands
        public ICommand Delete { get; set; }
        #endregion

        public ManagerViewModel()
        {
            CustomerList = new ObservableCollection<Customer>(Manager.CustomerList);
            Delete = new RelayCommand(DeleteCustomer);
        }

        #region Methods
        /// <summary>
        /// Add a new customer
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(Customer customer)
        {
            Manager.Add(customer);
            CustomerList = new ObservableCollection<Customer>(Manager.CustomerList);
        }
        /// <summary>
        /// Save customer to list
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="index"></param>
        public void SaveCustomer(Customer customer, int index)
        {
            Manager.Update(customer, index);
            CustomerList = new ObservableCollection<Customer>(Manager.CustomerList);
        }
        /// <summary>
        /// Delete selected customer to list
        /// </summary>
        public void DeleteCustomer()
        {
            Manager.DeleteCustomer(SelectedIndex);
            SelectedCustomer = null;
            CustomerList = new ObservableCollection<Customer>(Manager.CustomerList);
        }
        #endregion
    }
}
