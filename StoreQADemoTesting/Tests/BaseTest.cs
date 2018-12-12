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
using System.Threading;
using StoreQADemoTesting.MyClassExtensions;

namespace StoreQADemoTesting.Pages.Tests
{

    [TestFixture()]
    public abstract class BaseTest
    {

        protected WebDriverFactory _webDriverFactory;
        protected IWebDriver _driver;
        protected Random _rand;

        [SetUp()]
        public void SetUpM()
        {
            _webDriverFactory = new WebDriverFactory();
            _driver = _webDriverFactory.GetDriver();
            _driver.Navigate().GoToUrl("http://store.demoqa.com/");
        }

        [TearDown()]
        public void TearDownM()
        {
            Console.WriteLine(_driver.Url);
            _driver.TakeScreenShot();
            _driver.AnalyzeLog();
            _driver.Quit();
        }


        [Test()]
        public void DriverWorkingTest()
        {
            Assert.IsTrue(true);
        }

    }
}