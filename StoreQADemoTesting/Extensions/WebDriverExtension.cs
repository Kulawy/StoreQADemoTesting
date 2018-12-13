using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using StoreQADemoTesting.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions; DEPRECATED
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace StoreQADemoTesting.MyClassExtensions
{
    public static class WebDriverExtension
    {

        private static WebDriverWait wait;

        private static void IsWaitInitialized(IWebDriver driver)
        {
            if ( wait is null)
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            }

        }

        public static void AnalyzeLog(this IWebDriver driver)
        {
            //List<LogEntry> logEntries = driver.Manage().Logs.GetLog(LogType.Browser).ToList();
            try
            {
                var logEntries = driver.Manage().Logs.GetLog(LogType.Browser);
                foreach (LogEntry log in logEntries)
                {
                    Console.WriteLine(log.Message.ToString());
                    Console.WriteLine(log.ToString());
                }
                Console.WriteLine("Log is working, driver name: {0} ", driver.GetType().ToString().Split('.')[3]);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} has no log service", driver.GetType().ToString().Split('.')[3]);
                //Console.WriteLine(e.StackTrace);
            }
            
        }

        public static void TakeScreenShot(this IWebDriver driver)
        {
            try
            {
                Console.WriteLine("Date: " + System.DateTime.Now.ToString());
                string pathName = "C:/selenium/error_" + StringGenerator.GetRandomString(6) + ".png";
                Screenshot src = ((ITakesScreenshot)driver).GetScreenshot();
                src.SaveAsFile(pathName);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.GetType());
            }
        }

        

        public static void WaitUntilClickable(this IWebDriver driver, IWebElement element)
        {
            IsWaitInitialized(driver);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitForElements(this IWebDriver driver, List<IWebElement> elements)
        {
            IsWaitInitialized(driver);
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

        public static bool IsElementVisible(this IWebDriver driver, IWebElement element)
        {
            IsWaitInitialized(driver);
            return element.Displayed && element.Enabled;
        }

        public static void WaitUntilElementIsVisible_MF(this IWebDriver driver, IWebElement element)
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IsWaitInitialized(driver);
            wait.Until(x => element.Displayed);
        }

        public static void WaitForElement(this IWebDriver driver, IWebElement element)
        {
            IsWaitInitialized(driver);
            wait.Until(x => element.Displayed);
        }

        public static void WaitForCountToChange(this IWebDriver driver, IWebElement element, string text)
        {
            IsWaitInitialized(driver);
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

    }

}
