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

namespace StoreQADemoTesting.Pages.ProductCategoryPage
{
    public class ProductPage : WebElementManipulator
    {
        private List<IWebElement> elementsList;

        //public ProductPage(IWebDriver driver, MainMenuBarPage mainMenuBar) : base(driver)
        public ProductPage(IWebDriver driver) : base(driver)
        {
            //_bar = mainMenuBar;
            _bar = new MainMenuBarPage(_driver);
            _single = CurrentOrderHolderSingleton.Instance;
            //#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(_driver, this);
            //#pragma warning restore CS0618 // Type or member is obsolete
            elementsList = new List<IWebElement> { ElementTitle, ElementAddToCart };
            _driver.WaitForElements(elementsList);
            rnd = new Random();
        }

        [FindsBy(How = How.ClassName, Using = "prodtitle")]
        private IWebElement ElementTitle { get; set; }
        [FindsBy(How = How.CssSelector, Using = "input[value='Add To Cart']")]
        private IWebElement ElementAddToCart { get; set; }
        [FindsBy(How = How.CssSelector, Using = "div[class='alert addtocart']")]
        private IWebElement ElementAlertAdd { get; set; }
        [FindsBy(How = How.ClassName, Using = "currentprice")]
        private IWebElement ElementCurrentPrice { get; set; }

        public ProductPage VerifyGoodProdLoaded(String chosenValue)
        {
            Assert.AreEqual(ParseStringToComparableValue(chosenValue), ParseStringToComparableValue(ElementTitle.Text));
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
            //Assert.AreEqual(_bar.CurrentOrder.GetAmount(), _bar.GetCount());
            Assert.AreEqual(_single.CurrentOrder.GetAmount(), _bar.GetCount());
            return this;
        }

        private void AddToCart()
        {
            ClickElement(ElementAddToCart);
            _driver.WaitForElement(ElementAlertAdd);
            GetType().Name.Log("(BEFORE) count on screen:   ", _bar.GetCount().ToString());
            GetType().Name.Log( "(BEFORE) totalCountOfProd:  ", _single.CurrentOrder.GetAmount().ToString());
            _driver.WaitForCountToChange(_bar.GetElementCount(), _single.CurrentOrder.GetAmount().ToString());
            GetType().Name.Log( "(AFTER)  count on screen:   ", _bar.GetCount().ToString());
            GetType().Name.Log( "(AFTER)  totalCountOfProd:  ", _single.CurrentOrder.GetAmount().ToString());
        }

        private String ParseStringToComparableValue(String inputString)
        {
            string outString = inputString.ParseStringToComparableValue();
            GetType().Name.Log( "Porduct Name", outString);
            return outString;
        }

        private void AddProduct()
        {
            Console.WriteLine(ElementCurrentPrice.Text.Substring(1).Replace(",", ""));
            Product newProd = new Product(ElementTitle.Text, decimal.Parse(ElementCurrentPrice.Text.Substring(1).Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture));
            _single.CurrentOrder.AddProduct(newProd);
            GetType().Name.Log("Product add: ", newProd.ToString());
        }
    }
}
