using System;
using System.Net.Mail;

namespace Customers.Domain.Entities
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Email))
                throw new ArgumentNullException("The Email field is required.");
            if(!IsValidEmail(Email))
                throw new ArgumentOutOfRangeException("The Email field is not in the correct format.");
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
