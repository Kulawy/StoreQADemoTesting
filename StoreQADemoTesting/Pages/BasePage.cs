using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using StoreQADemoTesting.Model;
using StoreQADemoTesting.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace StoreQADemoTesting.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;
        protected MainMenuBarPage _bar;
        protected Actions _actionsBuilder;
        protected CurrentOrderSingle _single;
        protected Random rnd;
        private WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            _single = CurrentOrderSingle.Instance;
        }

        // to nie jest nigdzie używane :D jest w zapasie :D taki As z rękawa jak już waity nie podziałają
        //wrzucic do clasy WebDriverExtension  (jako metoda rozszerzajaca)
        protected void WaitWhile(int timeWaiting)
        {
            Thread.Sleep(timeWaiting);
        }

        protected void WaitUntilClickable(IWebElement element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        protected void WaitForElements(List<IWebElement> elements)
        {
            wait.Until(x =>
            {
                foreach (IWebElement elem in elements)
                {
                    if (!elem.Displayed)
                    {
                        return false;
                    }
                }
                return true;
            });
        }

        private bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public void WaitUntilElementIsVisible_MATEUSZ_FUN(IWebElement element)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(x => element.Displayed);
        }

        protected void WaitForElement(IWebElement element)
        {
            wait.Until(x => element.Displayed);
        }

        protected void WaitForCountToChange(IWebElement element, String text)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

        

    }
}
