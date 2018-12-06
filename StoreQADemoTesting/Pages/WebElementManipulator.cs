using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Pages
{
    public abstract class WebElementManipulator : BasePage
    {
        public WebElementManipulator(IWebDriver driver): base(driver)
        {

        }


        public IWebElement ClickElement(IWebElement element)
        {
            WaitUntilClickable(element);
            element.Click();
            return element;
        }

        public IWebElement SendKeysToElement(IWebElement element, String value)
        {
            WaitUntilClickable(element);
            element.SendKeys(value);
            return element;
        }
    }
}
