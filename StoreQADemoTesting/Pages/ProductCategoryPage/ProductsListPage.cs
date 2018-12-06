﻿using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Pages.ProductCategoryPage
{
    public class ProductsListPage : WebElementManipulator
    {

        public String ChosenItemName { get; set; }
        private List<IWebElement> elementsPorductsList;

        public ProductsListPage(IWebDriver driver, MainMenuBarPage mainMenuBar) : base(driver)
        {
            _bar = mainMenuBar;
            PageFactory.InitElements(_driver, this);
            WaitForElement(ElementTitle);
            elementsPorductsList = new List<IWebElement>(ElementsPorductsList);
            WaitForElements(elementsPorductsList);
            rnd = new Random();

        }

        [FindsBy(How = How.ClassName, Using = "entry-title")]
        private IWebElement ElementTitle { get; set; }

        [FindsBy(How = How.ClassName, Using = "wpsc_product_title")]
        private IList<IWebElement> ElementsPorductsList { get; set; }

        public ProductsListPage randomProductChose()
        {
            int listSize = elementsPorductsList.Count;
            Console.WriteLine(GetType().Name + " productList size: " + listSize);  //tu jest CW
            IWebElement productItem = elementsPorductsList[rnd.Next(listSize)];
            ChosenItemName = productItem.Text;
            ClickElement(productItem);
            return this;
        }

        public ProductsListPage VerifyRandomCategoryChoose(String titleShouldDisplay)
        {
            Assert.AreEqual(titleShouldDisplay, ElementTitle.Text);
            return this;
        }

    }
}