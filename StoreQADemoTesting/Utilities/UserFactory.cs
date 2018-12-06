using OpenQA.Selenium;
using StoreQADemoTesting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Utilities
{
    public class UserFactory
    {
        private Random rnd;

        public UserFactory()
        {
            rnd = new Random();
        }

        public User CreateRandomUser(List<IWebElement> CountryList)
        {
            String firstName = RandomfillFirstName();
            String lastName = RandomfillLastName();
            String address = RandomfillAddress();
            String city = RandomfillCity();
            String state = RandomfillState();
            String country = RandomFillCountry(CountryList);
            String postalCode = RandomFillPostalCode();
            String phone = RandomFillPhone();

            return new User(firstName, lastName, address, city, state, country, postalCode, phone);
        }

        private String RandomFillCountry(List<IWebElement> countryList)
        {
            int i = rnd.Next(countryList.Count);
            IWebElement countryElement = countryList[i];
            return countryElement.Text;
        }

        private String RandomfillFirstName()
        {
            return "Firstname" + RandomStringOfLength5();
        }

        private String RandomfillLastName()
        {
            return "Lastname" + RandomStringOfLength5();
        }

        private String RandomfillAddress()
        {
            return "Some" + RandomStringOfLength5() + " Street " + rnd.Next(200);
        }

        private String RandomfillCity()
        {
            return "New York";
        }

        private String RandomfillState()
        {
            return "Other";
        }

        private String RandomFillPostalCode()
        {
            return (rnd.Next(89) + 10).ToString() + (rnd.Next(899) + 100).ToString();
        }

        private String RandomFillPhone()
        {
            return (rnd.Next(899) + 100).ToString() + " " + (rnd.Next(899) + 100).ToString() + " " + (rnd.Next(899) + 100).ToString();
        }

        private String RandomStringOfLength5()
        {
            rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
            
        }
    }
}
