using Deveel.Math;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using StoreQADemoTesting.Model;
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
        public ResultPage(IWebDriver driver, CurrentOrderSingle singleTone) : base(driver)
        {
            _bar = new MainMenuBarPage(_driver);
            //_single = singleTone;
            PageFactory.InitElements(_driver, this);
            List<IWebElement> elementListOfProducts_asList = new List<IWebElement>(ElementListofProducts);
            WaitForElements(elementListOfProducts_asList);
            rnd = new Random();
            converter = new MyConverter();
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
                BigDecimal expectedPrice = new BigDecimal(_single.CurrentOrder.GetProd(i).GetPrice(), 2);
                //expectedPrice = expectedPrice.SetScale(2, RoundingMode.HalfUp);
                BigDecimal expectedTotalPrice = new BigDecimal(_single.CurrentOrder.GetProd(i).GetTotalProductPrice(), 2);
                //expectedTotalPrice = expectedTotalPrice.SetScale(2, RoundingMode.HalfUp);

                int expectedAmount = _single.CurrentOrder.GetProd(i).GetQuantity();

                Assert.AreEqual(converter.parseStringToComparableValue(expectedName), GetName(i));
                Assert.AreEqual(expectedPrice, GetPrice(i));
                Assert.AreEqual(expectedTotalPrice, GetTotalPrice(i));
                Assert.AreEqual(expectedAmount, GetAmount(i));
            }
            return this;
        }

        public ResultPage VerifyTotalOrderWithShipment()
        {
            Assert.IsTrue(ElementTotals.Text.Replace(",", "").Contains(_single.CurrentOrder.GetTotalOrderPrice().ToString()));
            return this;
        }

        public ResultPage verifyShipment()
        {
            Assert.IsTrue(ElementTotals.Text.Replace(",", "").Contains(_single.CurrentOrder.GetShippingPrice().ToString()));
            return this;
        }

        private String GetName(int i)
        {
            return converter.parseStringToComparableValue(ElementListofProducts[i].FindElement(By.CssSelector("td:nth-child(1)")).Text);
        }

        private BigDecimal GetPrice(int i)
        {
            return converter.formPriceToBigDecimal(ElementListofProducts[i].FindElement(By.CssSelector("td:nth-child(2)")).Text);
        }

        private BigDecimal GetTotalPrice(int i)
        {
            return converter.formPriceToBigDecimal(ElementListofProducts[i].FindElement(By.CssSelector("td:nth-child(4)")).Text);
        }

        private int GetAmount(int i)
        {
            return Int32.Parse(ElementListofProducts[i].FindElement(By.CssSelector("td:nth-child(3)")).Text);

        }

    }
}
