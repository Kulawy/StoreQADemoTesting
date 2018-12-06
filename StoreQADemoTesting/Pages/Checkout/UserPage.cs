using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using StoreQADemoTesting.Model;
using StoreQADemoTesting.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace StoreQADemoTesting.Pages.Checkout
{
    public class UserPage : WebElementManipulator
    {

        private List<IWebElement> elementsList;
        private List<IWebElement> elementsCountriesList;

        private User u;

        public UserPage(IWebDriver driver, MainMenuBarPage mainMenuBar) : base(driver)
        {
            _bar = mainMenuBar;
            PageFactory.InitElements(_driver, this);
            elementsList = new List<IWebElement> { ElementSameBilling, ElementFirstName, ElementLastName, ElementAddress };
            WaitForElements(elementsList);
            rnd = new Random();
            SetUserCountry();
            converter = new MyConverter();
        }

        [FindsBy(How = How.Id, Using = "shippingSameBilling")]
        private IWebElement ElementSameBilling { get; set; }
        [FindsBy(How = How.Name, Using = "collected_data[9]")]
        private IWebElement ElementEmail { get; set; }
        [FindsBy(How = How.Name, Using = "collected_data[2]")]
        private IWebElement ElementFirstName { get; set; }
        [FindsBy(How = How.Name, Using = "collected_data[3]")]
        private IWebElement ElementLastName { get; set; }
        [FindsBy(How = How.Name, Using = "collected_data[4]")]
        private IWebElement ElementAddress { get; set; }
        [FindsBy(How = How.Name, Using = "collected_data[5]")]
        private IWebElement ElementCity { get; set; }
        [FindsBy(How = How.Name, Using = "collected_data[6]")]
        private IWebElement ElementState { get; set; }
        [FindsBy(How = How.Name, Using = "collected_data[7][0]")]
        private IWebElement ElementSelectCountry { get; set; }
        [FindsBy(How = How.Name, Using = "collected_data[8]")]
        private IWebElement ElementPostalCode { get; set; }
        [FindsBy(How = How.Name, Using = "collected_data[18]")]
        private IWebElement ElementPhone { get; set; }
        [FindsBy(How = How.CssSelector, Using = "input[value='Purchase']")]
        private IWebElement ElementPurchase { get; set; }

        [FindsBy(How = How.Id, Using = "current_country")]
        private IWebElement ElementShippingSelectCountry { get; set; }
        [FindsBy(How = How.Name, Using = "collected_data[15]")]
        private IWebElement ElementShippingState { get; set; }
        [FindsBy(How = How.Name, Using = "input[value='Calculate']")]
        private IWebElement ElementCalculate { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".total_shipping .checkout-shipping .pricedisplay")]
        private IWebElement ElementShipping { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#change_country #uniform-wpsc_checkout_form_16_region")]
        private IWebElement ElementToAcceptShipping { get; set; }
        [FindsBy(How = How.CssSelector, Using = "#uniform-wpsc_checkout_form_7_region")]
        private IWebElement ElementToSetStateShipping { get; set; }
        [FindsBy(How = How.CssSelector, Using = "span[class='pricedisplay checkout-shipping']")]
        private IWebElement ElementShippingPrice { get; set; }



        private void SetUserCountry()
        {
            var countrySelect = new SelectElement(ElementSelectCountry);
            elementsCountriesList = new List<IWebElement>(countrySelect.Options);
        }

        public List<IWebElement> GetAviableCountries()
        {
            return elementsCountriesList;
        }

        public UserPage SetUser(User user)
        {
            u = user;
            return this;
        }

        public UserPage SetAll()
        {
            SendKeysToElement(ElementEmail, u.Email);
            SendKeysToElement(ElementFirstName, u.FirstName);
            SendKeysToElement(ElementLastName, u.LastName);
            SendKeysToElement(ElementAddress, u.Address);
            SendKeysToElement(ElementCity, u.City);
            SendKeysToElement(ElementState, u.State);
            SetCountry(ElementSelectCountry, u.Country);
            SendKeysToElement(ElementPostalCode, u.PostalCode);
            SendKeysToElement(ElementPhone, u.Phone);
            SetCountry(ElementShippingSelectCountry, u.Country);
            SendKeysToElement(ElementShippingState, u.State);
            Log(GetType().Name, " User Added: ", u.ToString());
            return this;
        }

        public UserPage Calculate()
        {
            ClickElement(ElementToSetStateShipping);
            ClickElement(ElementToAcceptShipping);
            return this;
        }

        public UserPage Purchase()
        {
            ClickElement(ElementPurchase);
            return this;
        }

        public UserPage SelectShippingSame()
        {
            ClickElement(ElementSameBilling);
            return this;
        }

        private void SetCountry(IWebElement elem, String countryName)
        {
            var countrySelect = new SelectElement(elem);
            countrySelect.SelectByText(countryName);
        }

        public UserPage GetShippingPrice()
        {
            if (_driver.Url == "http://store.demoqa.com/products-page/checkout/")
            {
                WaitForElement(ElementShippingPrice);
                _bar.CurrentOrder.SetShippingPirce(converter.formPriceToBigDecimal(ElementShippingPrice.Text));
                ClickElement(ElementPurchase);
            }
            else
            {
                _bar.CurrentOrder.SetShippingPirce(converter.formPriceToBigDecimal("0"));
            }
            return this;
        }

        public String GetCountryFromPage()
        {
            var countrySelect = new SelectElement(ElementSelectCountry);
            //IList<IWebElement> countrySelectIList = countrySelect.Options;
            //List<IWebElement> countrySelectOptions = elementCount as List<IWebElement>;
            return countrySelect.SelectedOption.Text;
        }

        public Boolean IsFirstNameFilled()
        {

            if (ElementFirstName != null && ElementFirstName.Text != "")
                return true;
            else
                return false;
        }

    }
}
