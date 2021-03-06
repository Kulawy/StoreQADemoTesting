﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using StoreQADemoTesting.Model;
using StoreQADemoTesting.MyClassExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Pages
{
    public class MainMenuBarPage : WebElementManipulator
    {

        public MainMenuBarPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
            _actionsBuilder = new Actions(_driver);
            List<IWebElement> elements = new List<IWebElement>() { elementAllProd, elementCheckout, elementHome, elementNoTitle, elementProdCat };
            _driver.WaitForElements(elements);
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
            _driver.WaitForElement(elementProdCat);
            _actionsBuilder.MoveToElement(elementProdCat).Build().Perform();
            return this;
        }

        public MainMenuBarPage OpenHome()
        {
            ClickElement(elementHome);
            return this;
        }

        public MainMenuBarPage OpenProductCategory()
        {
            ClickElement(elementProdCat);
            return this;
        }

        public MainMenuBarPage OpenNoTitle()
        {
            ClickElement(elementNoTitle);
            return this;
        }

        public MainMenuBarPage OpenAllProduct()
        {
            ClickElement(elementAllProd);
            return this;
        }

        public MainMenuBarPage OpenCheckout()
        {
            ClickElement(elementCheckout);
            return this;
        }


        public IWebElement GetElementCount()
        {
            return elementCount;
        }

        public int GetCount()
        {
            String value = elementCount.Text.Replace(" ", "");
            return Int32.Parse(value);
        }
    }
}
