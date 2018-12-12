using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Pages
{
    public class ProductCategoryBarPage : WebElementManipulator
    {

        private List<IWebElement> elementsList;
        public String choosenElementText;

        public ProductCategoryBarPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(_driver, this);
            elementsList = new List<IWebElement> { ElementAccessories, ElementIMacs, ElementIPads, ElementIPhones, ElementIPods, ElementMacBooks };
            WaitForElements(elementsList);
            rnd = new Random();
        }

        //@FindBy(id = "menu-item-34")
        private IWebElement ElementAccessories => _driver.FindElement(By.Id("menu-item-34"));

        //@FindBy(id = "menu-item-35")
        private IWebElement ElementIMacs => _driver.FindElement(By.Id("menu-item-35"));

        //@FindBy(id = "menu-item-36")
        private IWebElement ElementIPads => _driver.FindElement(By.Id("menu-item-36"));

        //@FindBy(id = "menu-item-37")
        private IWebElement ElementIPhones => _driver.FindElement(By.Id("menu-item-37"));

        //@FindBy(id = "menu-item-38")
        private IWebElement ElementIPods => _driver.FindElement(By.Id("menu-item-38"));

        //@FindBy(id = "menu-item-39")
        private IWebElement ElementMacBooks => _driver.FindElement(By.Id("menu-item-39"));

        public ProductCategoryBarPage SelectRandom()
        {
            IWebElement randomElement = elementsList[rnd.Next(6)];
            choosenElementText = randomElement.Text;
            ClickElement(randomElement);
            return this;
        }

    }
}
