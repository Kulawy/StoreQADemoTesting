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
        public String Email => FirstName.Substring(0, 1) + "." + LastName + "@gmail.com";

        public User()
        {

        }

        public User(String firstName, String lastName, String address, String city, String state, String country, String postalCode, String phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
            Phone = phone;
            //Email = this.FirstName.Substring(0, 1) + "." + this.LastName + "@gmail.com";
        }
        

        public override String ToString()
        {
            return FirstName + " " + LastName + " " + Address + " " + City + " " + State + " " + Country + " " + PostalCode + Phone + " " + Email;
        }

    }
}
