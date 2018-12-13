using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using StoreQADemoTesting.Model;
using System;

namespace StoreQADemoTesting.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;
        protected MainMenuBarPage _bar;
        protected Actions _actionsBuilder;
        protected CurrentOrderHolderSingleton _single;
        protected Random rnd;
        private WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _single = CurrentOrderHolderSingleton.Instance;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }
        
    }
}
