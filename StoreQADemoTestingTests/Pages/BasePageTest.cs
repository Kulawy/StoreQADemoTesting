using NUnit.Framework;
using StoreQADemoTesting.Pages;
using StoreQADemoTesting.Utilities.WebDriverUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using StoreQADemoTesting.Model;

namespace StoreQADemoTesting.Pages.Tests
{

    [TestFixture()]
    public abstract class BasePageTest
    {

        protected WebDriverFactory _webDriverFactory;
        protected IWebDriver _driver;
        //protected MainMenuBarPage _bar;
        //protected CurrentOrderSingle _single;
        protected Random _rand;

        [SetUp()]
        public void SetUpM()
        {
            _webDriverFactory = new WebDriverFactory();
            _driver = _webDriverFactory.GetDriver();
            //try
            //{
            //    _driver = _webDriverFactory.GetDriver();
            //    Console.WriteLine("Taki webDriver: " + _driver.GetType().ToString());
            //}
            //catch (Exception e)
            //{
            //    e.ToString();
            //}

            _driver.Navigate().GoToUrl("http://store.demoqa.com/");
        }

        [TearDown()]
        public void TearDownM()
        {
            Console.WriteLine(_driver.Url);
            TakeScreenShot();
            _driver.Quit();
        }

        protected void TakeScreenShot()
        {
            //File src = ((ITakesScreenshot) _driver).GetScreenshot();
            try
            {
                // now copy the  screenshot to desired location using copyFile
                String pathName = "C:/selenium/error_" + CreateImgPathToken() + ".png";
                Screenshot src = ((ITakesScreenshot)_driver).GetScreenshot();
                src.SaveAsFile(pathName);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.GetType());
            }
        }

        private String CreateImgPathToken()
        {
            _rand = new Random();
            int[] arrayInt = new int[6];
            char[] arrayChar = new char[6];
            for (int i = 0; i < 6; i++)
            {
                arrayInt[i] = _rand.Next(10);
                arrayChar[i] = (char)(arrayInt[i] + '0');
            }
            String imgPathToken = (arrayChar).ToString();
            Console.WriteLine(imgPathToken);
            return imgPathToken;
        }



        [Test()]
        public void HoverProductCategoryTest()
        {
            Assert.IsTrue(true);
        }

    }
}