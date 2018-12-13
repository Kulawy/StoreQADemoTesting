using OpenQA.Selenium;
using StoreQADemoTesting.Model;
using StoreQADemoTesting.MyClassExtensions;
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

            User user = new User()
            {
                FirstName = "Firstname" + StringGenerator.GetRandomString(5),
                LastName = "Lastname" + StringGenerator.GetRandomString(5),
                Address = "Some" + StringGenerator.GetRandomString(5) + " Street " + rnd.Next(200),
                City = RandomfillCity(),
                State = RandomfillState(),
                Country = RandomFillCountry(CountryList),
                PostalCode = RandomFillPostalCode(),
                Phone = RandomFillPhone()
            };
            return user;
        }

        private String RandomFillCountry(List<IWebElement> countryList)
        {
            int i = rnd.Next(countryList.Count);
            IWebElement countryElement = countryList[i];
            return countryElement.Text;
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


    }
}
