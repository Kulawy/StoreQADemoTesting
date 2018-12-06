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

namespace StoreQADemoTesting.Pages.ProductCategoryPage
{
    public class ProductPage : WebElementManipulator
    {
        private List<IWebElement> elementsList;

        public ProductPage(IWebDriver driver, MainMenuBarPage mainMenuBar) : base(driver)
        {
            _bar = mainMenuBar;
            #pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(_driver, this);
            #pragma warning restore CS0618 // Type or member is obsolete
            elementsList = new List<IWebElement> { elementTitle, elementAddToCart };
            WaitForElements(elementsList);
            rnd = new Random();
            converter = new MyConverter();
        }

        [FindsBy(How = How.ClassName, Using = "prodtitle")]
        private IWebElement elementTitle { get; set; }
        [FindsBy(How = How.CssSelector, Using = "input[value='Add To Cart']")]
        private IWebElement elementAddToCart { get; set; }
        [FindsBy(How = How.CssSelector, Using = "div[class='alert addtocart']")]
        private IWebElement elementAlertAdd { get; set; }
        [FindsBy(How = How.ClassName, Using = "currentprice")]
        private IWebElement elementCurrentPrice { get; set; }

        public ProductPage VerifyGoodProdLoaded(String chosenValue)
        {
            Assert.AreEqual(ParseStringToComparableValue(chosenValue), ParseStringToComparableValue(elementTitle.Text));
            return this;
        }

        public ProductPage AddRandomCountOfProductToCart()
        {
            int countOfProduct = rnd.Next(3) + 1;
            for (int i = 1; i <= countOfProduct; i++)
            {
                AddProduct();
                AddToCart();
            }
            return this;
        }

        public ProductPage AddOneProductToCart()
        {
            AddProduct();
            AddToCart();
            return this;
        }

        public ProductPage VerifyAmount()
        {
            Assert.AreEqual(_bar.CurrentOrder.GetAmount(), _bar.getCount());
            return this;
        }

        private void AddToCart()
        {
            ClickElement(elementAddToCart);
            WaitForElement(elementAlertAdd);
            Log(GetType().Name, "(BEFORE) count on screen:   ", _bar.getCount().ToString());
            Log(GetType().Name, "(BEFORE) totalCountOfProd:  ", _bar.CurrentOrder.GetAmount().ToString());
            WaitForCountToChange(_bar.getElementCount(), _bar.CurrentOrder.GetAmount().ToString());
            Log(GetType().Name, "(AFTER)  count on screen:   ", _bar.getCount().ToString());
            Log(GetType().Name, "(AFTER)  totalCountOfProd:  ", _bar.CurrentOrder.GetAmount().ToString());
        }

        private String ParseStringToComparableValue(String inputString)
        {
            string outString = converter.parseStringToComparableValue(inputString);
            Log(GetType().Name, " Porduct Name", outString);
            return outString;
        }

        private void AddProduct()
        {
            Console.WriteLine(elementCurrentPrice.Text.Substring(1).Replace(",", ""));
            Product newProd = new Product(elementTitle.Text, new BigDecimal(double.Parse(elementCurrentPrice.Text.Substring(1).Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture)));
            _bar.CurrentOrder.AddProduct(newProd);
            Log(GetType().Name, "Product add: ", newProd.ToString());
        }
    }
}
