using CustomerRegistry.Data.CustomerData;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomerRegistry.Data
{
    public class Manager
    {
        #region fields
        private List<Customer> customerList = new List<Customer>();
        #endregion

        #region propertys
        /// <summary>
        /// List of Customers
        /// </summary>
        public List<Customer> CustomerList { get => customerList; set => customerList = value; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Manager() 
        { 
        
        }
        #endregion

        #region Methods

        public void Add(Customer customer)
        {
            customerList.Add(customer);
        }

        public void DeleteCustomer(int index)
        {
            CustomerList.RemoveAt(index);
        }

        public void Update(Customer customer, int index)
        {
            CustomerList[index] = customer;
        }
        /// <summary>
        /// Method for geting an unique ID for a new customer
        /// </summary>
        /// <returns>ID</returns>
        public int GetFreeId()
        {
           // MessageBox.Show(CustomerList.Count.ToString());
            if (customerList.Count == 0)
                return 1;
            else
                return CheckUsed();
        }
        /// <summary>
        /// Methods that checks which ID:s are in use
        /// </summary>
        /// <returns>List of used ID:s </returns>
        private List<int> UsedIds()
        {
            List<int> listOfUsed = customerList.Select(c => c.Id).ToList();
            listOfUsed.Sort();
            return listOfUsed;
        }
        /// <summary>
        /// Loops through list of used ID:s
        /// </summary>
        /// <returns>Unused ID</returns>
        private int CheckUsed()
        {
            List<int> listOfUsed = UsedIds();
            for (int i = 1; i < customerList.Count + 1; i++)
            {
                if (i != listOfUsed[i - 1])
                    return i;                 
            }
            return customerList.Count + 1;
        }
        #endregion
    }
}
