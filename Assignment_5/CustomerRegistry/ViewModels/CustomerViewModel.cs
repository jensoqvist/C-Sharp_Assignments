using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CustomerRegistry.Data.CustomerData;
using CustomerRegistry.UserControls;

namespace CustomerRegistry.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        #region UserControls for view
        private UserControl side = new AddCustomerSideUC();
        public UserControl Side { get => side; set => side = value; }

        private UserControl main = new AddCustomerUC();
        public UserControl Main { get => main; set => main = value; }
        #endregion

        #region fields
        private Customer curCustomer;
        private bool validInput;
        bool firstValid;
        bool lastValid;
        bool phoneValid;
        bool emailValid;
        #endregion

        #region propertys
        /// <summary>
        /// Current Customer
        /// </summary>
        public Customer CurCustomer { get => curCustomer; set {  curCustomer = value; OnPropertyChanged(); } }
        /// <summary>
        /// Does the input meet the reqs
        /// </summary>
        public bool ValidInput { get => CheckInput(); }
        public string ValidFields { get => ReturnValidFields(); }
        public string ReqText { get => Requirements(); }

        public int[] Countries { get; set; } = (int[])Enum.GetValues(typeof(Countries));
        #endregion

        #region Commands
        public ICommand Clear { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CustomerViewModel() 
        {
            Clear = new RelayCommand(ClearCustomer);
        }

        #endregion

        #region Methods
        public void ClearCustomer()
        {
            int id = CurCustomer.Id;
            CurCustomer = new Customer(id);
        }
        /// <summary>
        /// Checks if all the correct input is given
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            firstValid = CurCustomer.FirstName.Length > 0;
            lastValid = CurCustomer.LastName.Length > 0;
            emailValid = false;
            if (CurCustomer.Contact.Email.Personal != null && CurCustomer.Contact.Email.Personal.Contains("@") && CurCustomer.Contact.Email.Personal.Contains("."))
                emailValid = true;
            if (CurCustomer.Contact.Email.Work != null && CurCustomer.Contact.Email.Work.Contains("@") && CurCustomer.Contact.Email.Work.Contains("."))
                emailValid = true;
            phoneValid = false;
            if ((CurCustomer.Contact.Phone.Private.Length > 0) && CurCustomer.Contact.Phone.Private.All(Char.IsDigit) || (CurCustomer.Contact.Phone.Office.Length > 0) && CurCustomer.Contact.Phone.Office.All(Char.IsDigit))
                phoneValid = true;
            if (firstValid && lastValid && phoneValid && emailValid)
                return  true;
            return false;
        }
        /// <summary>
        /// Check what is missing
        /// </summary>
        /// <returns> String explaining what is needed to meet requirements</returns>
        private string ReturnValidFields()
        {
            string req = string.Empty;
            req += "Please correct the following to be able to save:\n\n";
            if (!firstValid)
                req += "First name need to be at least one character\n";
            if(!lastValid)
                req += "Last name need to be at least one character\n";
            if (!phoneValid)
                req += "At least one correct phone number must be input, only numbers allowed\n\n";
            if (!emailValid)
                req += "One valid Email is required";
            return req;
        }

        private string Requirements()
        {
            string reqString = "Requirements:\n\n";
            reqString += "First and last name must be input.\n\n";
            reqString += "At least one correct phone number, containing only digits must be input\n\n";
            reqString += "One valid Emailadress containing an @ and a .";
            return reqString;
        }
        #endregion

    }
}
