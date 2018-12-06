using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using StoreQADemoTesting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Pages
{
    public class MainMenuBarPage : WebElementManipulator
    {
        public Order CurrentOrder { get; set; }

        public MainMenuBarPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
            _actionsBuilder = new Actions(_driver);
            List<IWebElement> elements = new List<IWebElement>() { elementAllProd, elementCheckout, elementHome, elementNoTitle, elementProdCat };
            WaitForElements(elements);
            CurrentOrder = new Order();
        }

        [FindsBy(How = How.Id, Using = "menu-item-15")]
        private IWebElement elementHome { get; set; }
        [FindsBy(How = How.Id, Using = "menu-item-33")]
        private IWebElement elementProdCat { get; set; }
        [FindsBy(How = How.Id, Using = "menu-item-16")]
        private IWebElement elementNoTitle { get; set; }
        [FindsBy(How = How.Id, Using = "menu-item-72")]
        private IWebElement elementAllProd { get; set; }
        [FindsBy(How = How.Id, Using = "header_cart")]
        private IWebElement elementCheckout { get; set; }
        [FindsBy(How = How.CssSelector, Using = "em[class='count']")]
        private IWebElement elementCount { get; set; }


        public MainMenuBarPage HoverProductCategory()
        {
            WaitForElement(elementProdCat);
            _actionsBuilder.MoveToElement(elementProdCat).Build().Perform();
            //_actionsBuilder.Build().Perform();
            return this;
        }

        public MainMenuBarPage openHome()
        {
            ClickElement(elementHome);
            return this;
        }

        public MainMenuBarPage OpenProductCategory()
        {
            ClickElement(elementProdCat);
            return this;
        }

        public MainMenuBarPage openNoTitle()
        {
            ClickElement(elementNoTitle);
            return this;
        }

        public MainMenuBarPage openAllProduct()
        {
            ClickElement(elementAllProd);
            return this;
        }

        public MainMenuBarPage openCheckout()
        {
            ClickElement(elementCheckout);
            return this;
        }


        public IWebElement getElementCount()
        {
            return elementCount;
        }

        public int getCount()
        {
            String value = elementCount.Text.Replace(" ", "");
            //System.out.println(this.getClass().getName() + " count value: "+ value);
            return Int32.Parse(value);
            //return Integer.parseInt(elementCount.getText().trim());
        }
    }
}
