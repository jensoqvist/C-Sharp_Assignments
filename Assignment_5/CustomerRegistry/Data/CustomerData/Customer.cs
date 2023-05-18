using CustomerRegistry.Data.CustomerData.ContactData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomerRegistry.Data.CustomerData
{
    /// <summary>
    /// Class describing a custumer including contactinformation
    /// </summary>
    public class Customer
    {
        

        #region private fields
        private int id;
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private Contact contact = new Contact();
        #endregion


        #region public propertys
        /// <summary>
        /// Customer ID
        /// </summary>
        public int Id { get { return id; }}
        /// <summary>
        /// Customers First name
        /// </summary>
        public string FirstName { get { return firstName; } set { firstName = value; } }
        /// <summary>
        /// Customers lastname
        /// </summary>
        public string LastName { get { return lastName; } set { lastName = value; } }
        /// <summary>
        /// Customers contact information. Adress, Country, Email and Phone
        /// </summary>
        public Contact Contact { get { return contact; } set { contact = value; } }
        public string Description { get => ToString(); }
        #endregion


        #region Constructor
        /// <summary>
        ///  Default Costructor
        /// </summary>
        /// <param name="newId"> Customer ID for new customer</param>
        public Customer(int newId) 
        {
            id = newId;
        }
        #endregion

        #region Methods
        public Customer DeepCopy()
        {
            Customer deepCopy = new Customer(this.Id)
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                
            };
            deepCopy.Contact.Email.Work = this.Contact.Email.Work;
            deepCopy.Contact.Email.Personal = this.Contact.Email.Personal;
            deepCopy.Contact.Phone = this.Contact.Phone.DeepCopy();
            deepCopy.Contact.Adress = this.Contact.Adress.DeepCopy();

            return deepCopy; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Description of customer</returns>
        public override string ToString()
        {
            string description = string.Format("Customer ID: {0}\n\n", id.ToString());
            description += string.Format("First name: {0}\n", firstName);
            description += string.Format("Last name: {0}\n\n\n", lastName);
            description += string.Format("Contact information:\n" + Contact.ToString());
            return description;
        }
        #endregion

    }
}
