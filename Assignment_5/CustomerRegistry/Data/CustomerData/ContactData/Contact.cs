using CustomerRegistry.Data.CustomerData.ContactData.bin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistry.Data.CustomerData.ContactData
{
    /// <summary>
    /// Contact informatin of customer
    /// </summary>
    public class Contact
    {
        private Adress adress = new();
        private Email email = new();
        private Phone phone = new();

        public Adress Adress { get { return adress; } set {  adress = value; } }
        public Email Email { get { return email; } set { email = value; } }
        public Phone Phone { get { return phone; } set { phone = value; } }

        public override string ToString()
        {
            string contact = string.Empty;
            contact += string.Format("Phone:\n" + phone.ToString());
            contact += Email.ToString();
            contact += string.Format("Adress:\n" + adress.ToString());
            return contact;
        }

    }
}
