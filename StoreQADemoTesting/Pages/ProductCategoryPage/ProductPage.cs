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

        //public ProductPage(IWebDriver driver, MainMenuBarPage mainMenuBar) : base(driver)
        public ProductPage(IWebDriver driver) : base(driver)
        {
            //_bar = mainMenuBar;
            _bar = new MainMenuBarPage(_driver);
            _single = CurrentOrderSingle.Instance;
            //#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(_driver, this);
            //#pragma warning restore CS0618 // Type or member is obsolete
            elementsList = new List<IWebElement> { ElementTitle, ElementAddToCart };
            WaitForElements(elementsList);
            rnd = new Random();
            converter = new MyConverter();
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
            WaitForElement(ElementAlertAdd);
            Log(GetType().Name, "(BEFORE) count on screen:   ", _bar.GetCount().ToString());
            Log(GetType().Name, "(BEFORE) totalCountOfProd:  ", _single.CurrentOrder.GetAmount().ToString());
            WaitForCountToChange(_bar.GetElementCount(), _single.CurrentOrder.GetAmount().ToString());
            Log(GetType().Name, "(AFTER)  count on screen:   ", _bar.GetCount().ToString());
            Log(GetType().Name, "(AFTER)  totalCountOfProd:  ", _single.CurrentOrder.GetAmount().ToString());
        }

        private String ParseStringToComparableValue(String inputString)
        {
            string outString = converter.ParseStringToComparableValue(inputString);
            Log(GetType().Name, " Porduct Name", outString);
            return outString;
        }

        private void AddProduct()
        {
            Console.WriteLine(ElementCurrentPrice.Text.Substring(1).Replace(",", ""));
            Product newProd = new Product(ElementTitle.Text, new BigDecimal(double.Parse(ElementCurrentPrice.Text.Substring(1).Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture)));
            _single.CurrentOrder.AddProduct(newProd);
            Log(GetType().Name, "Product add: ", newProd.ToString());
        }
    }
}
