using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.MyClassExtensions
{
    public static class WebDriverExtension
    {
        public static void AnalyzeLog(this IWebDriver driver)
        {
            List<LogEntry> logEntries = driver.Manage().Logs.GetLog(LogType.Browser).ToList();
            foreach (LogEntry log in logEntries)
            {
                Console.WriteLine(log.Message);
                //do something useful with the data
            }
        }

        public static void TakeScreenShot(this IWebDriver driver)
        {
            try
            {
                Console.WriteLine("Date: " + System.DateTime.Now.ToString());
                string pathName = "C:/selenium/error_" +  "".GetRandomString(6) + ".png";
                Screenshot src = ((ITakesScreenshot)driver).GetScreenshot();
                src.SaveAsFile(pathName);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.GetType());
            }
        }



    }
}
