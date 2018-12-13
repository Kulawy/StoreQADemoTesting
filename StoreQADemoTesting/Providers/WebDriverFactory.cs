using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
//using OpenQA.Selenium.Remote.DesiredCapabilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Utilities.WebDriverUtilities
{
    public class WebDriverFactory
    {
        private static readonly string _HUB_URI = "http://192.168.56.1:4440/wd/hub";

        protected String browserName;
        protected String driverUrl;

        public WebDriverFactory()
        {
            try
            {
                PropertiesFilesReader propFR = new PropertiesFilesReader();
                //browserName = propFR.GetBrowser();
                browserName = propFR.Browser;
                //tutaj od razu parsować stringa na enuma i bez case sensitive
                driverUrl = propFR.GetUrl();

            }
            catch (InvalidOperationException e)
            {
                e.ToString();
            }

        }

        //TODO zrobić enuma 
        public IWebDriver GetDriver() //throws MalformedURLException
        {
            switch (browserName)
            {
                case "Chrome":
                    return GetChromeDriver();
                case "Firefox":
                    return GetFireFoxDriver();
                case "Edge":
                    return GetEdgeDriver();
                case "IE":
                    return GetIEDriver();
                case "gridChrome":
                    return GetGridChrome();
                case "gridFirefox":
                    return GetGridFirefox();
                case "gridEdge":
                    return GetGridEdge();
                case "gridIE":
                    return GetGridIE();
                default:
                    Console.WriteLine("cos nie tak z ladowaniem propertisow");
                    return GetChromeDriver();
            }

        }

        private IWebDriver GetGridFirefox() //throws MalformedURLException
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddAdditionalCapability("ignoreProtectedModeSettings", true);
            options.AddAdditionalCapability("EnsureCleanSession", true);
            IWebDriver _webdriver = new RemoteWebDriver(new Uri(_HUB_URI), options.ToCapabilities(), TimeSpan.FromSeconds(300));
            return _webdriver;

            //TAK W JAVA
            //DesiredCapabilities dc = DesiredCapabilities.Firefox();    
            //IWebDriver driver = new RemoteWebDriver(new URL(_HUB_URI), dc);
            //return driver;
        }

        private IWebDriver GetGridChrome() //throws MalformedURLException
        {
            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability("ignoreProtectedModeSettings", true);
            options.AddAdditionalCapability("EnsureCleanSession", true);
            IWebDriver _webdriver = new RemoteWebDriver(new Uri(_HUB_URI), options.ToCapabilities(), TimeSpan.FromSeconds(300));
            return _webdriver;
        }

        private IWebDriver GetGridEdge() // throws MalformedURLException
        {
            EdgeOptions options = new EdgeOptions();
            options.AddAdditionalCapability("ignoreProtectedModeSettings", true);
            options.AddAdditionalCapability("EnsureCleanSession", true);
            IWebDriver _webdriver = new RemoteWebDriver(new Uri(_HUB_URI), options.ToCapabilities(), TimeSpan.FromSeconds(300));
            return _webdriver;
        }

        private IWebDriver GetGridIE() // throws MalformedURLException
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.AddAdditionalCapability("ignoreProtectedModeSettings", true);
            options.AddAdditionalCapability("EnsureCleanSession", true);
            IWebDriver _webdriver = new RemoteWebDriver(new Uri(_HUB_URI), options.ToCapabilities(), TimeSpan.FromSeconds(300));
            return _webdriver;
        }

        private IWebDriver GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-extensions");
            IWebDriver driver = new ChromeDriver(options);
            
            return driver;
        }

        private IWebDriver GetFireFoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("disable-extensions");
            IWebDriver driver = new FirefoxDriver(options);
            driver.Manage().Window.Maximize();
            return driver;
        }

        private IWebDriver GetEdgeDriver()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        private IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

    }
}
