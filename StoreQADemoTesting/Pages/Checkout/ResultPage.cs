using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using StoreQADemoTesting.Model;
using StoreQADemoTesting.MyClassExtensions;
using StoreQADemoTesting.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Pages.Checkout
{
    public class ResultPage : WebElementManipulator
    {

        //public ResultPage(IWebDriver driver, MainMenuBarPage mainMenuBar) : base(driver)
        public ResultPage(IWebDriver driver) : base(driver)
        {
            _bar = new MainMenuBarPage(_driver);
            _single = CurrentOrderSingle.Instance;
            PageFactory.InitElements(_driver, this);
            List<IWebElement> elementListOfProducts_asList = new List<IWebElement>(ElementListofProducts);
            WaitForElements(elementListOfProducts_asList);
            rnd = new Random();
        }

        [FindsBy(How = How.CssSelector, Using = "tbody tr")] // O CO KAMAN!!!
        private IList<IWebElement> ElementListofProducts { get; set; }
        [FindsBy(How = How.XPath, Using = "//p[contains( text(), 'Total')]")]
        private IWebElement ElementTotals;

        public ResultPage VerifyOrder()
        {
            for (int i = 0; i < ElementListofProducts.Count; i++)
            {
                String expectedName = _single.CurrentOrder.GetProd(i).GetName();
                decimal expectedPrice = _single.CurrentOrder.GetProd(i).GetPrice();
                //BigDecimal expectedPrice2 = converter.FormPriceToBigDecimal(_single.CurrentOrder.GetProd(i).GetPrice()); ;
                //expectedPrice = expectedPrice.SetScale(2, RoundingMode.HalfUp);
                decimal expectedTotalPrice = _single.CurrentOrder.GetProd(i).GetTotalProductPrice();
                //BigDecimal expectedTotalPrice = new BigDecimal(_single.CurrentOrder.GetProd(i).GetTotalProductPrice(), 2);
                //expectedTotalPrice = expectedTotalPrice.SetScale(2, RoundingMode.HalfUp);

                int expectedAmount = _single.CurrentOrder.GetProd(i).GetQuantity();

                Assert.AreEqual(expectedName.ParseStringToComparableValue(), GetName(i));
                Assert.AreEqual(expectedPrice, GetPrice(i));
                Assert.AreEqual(expectedTotalPrice, GetTotalPrice(i));
                Assert.AreEqual(expectedAmount, GetAmount(i));
            }
            return this;
        }

        public ResultPage VerifyTotalOrderWithShipment()
        {
            GetType().Name.Log("Values: ", ElementTotals.Text.Replace(",", "") + " / " + _single.CurrentOrder.GetTotalOrderPrice().ToString());
            Assert.IsTrue(ElementTotals.Text.Replace(",", "").Contains(_single.CurrentOrder.GetTotalOrderPrice().ToString().Replace(",",".")));
            return this;
        }

        public ResultPage VerifyShipment()
        {
            Assert.IsTrue(ElementTotals.Text.Replace(",", "").Contains(_single.CurrentOrder.GetShippingPrice().ToString()));
            return this;
        }

        private String GetName(int i)
        {
            string name = ElementListofProducts[i].FindElement(By.CssSelector("td:nth-child(1)")).Text;
            return name.ParseStringToComparableValue();
        }

        private decimal GetPrice(int i)
        {
            string price = ElementListofProducts[i].FindElement(By.CssSelector("td:nth-child(2)")).Text;
            return price.FormPriceToBigDecimal();
        }

        private decimal GetTotalPrice(int i)
        {
            string totalPrice = ElementListofProducts[i].FindElement(By.CssSelector("td:nth-child(4)")).Text;
            return totalPrice.FormPriceToBigDecimal();
        }

        private int GetAmount(int i)
        {
            return Int32.Parse(ElementListofProducts[i].FindElement(By.CssSelector("td:nth-child(3)")).Text);
        }

    }
}
