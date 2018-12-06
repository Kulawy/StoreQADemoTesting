using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Model
{
    public class User
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }
        public String PostalCode { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }

        public User(String firstName, String lastName, String address, String city, String state, String country, String postalCode, String phone)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.PostalCode = postalCode;
            this.Phone = phone;
            this.Email = this.FirstName.Substring(0, 1) + "." + this.LastName + "@gmail.com";
        }

        public override String ToString()
        {
            return FirstName + " " + LastName + " " + Address + " " + City + " " + State + " " + Country + " " + PostalCode + Phone + " " + Email;
        }

    }
}
