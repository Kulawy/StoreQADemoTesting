using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using StoreQADemoTesting.Model;
using StoreQADemoTesting.MyClassExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Pages.Checkout
{
    public class CheckoutPage : WebElementManipulator
    {

        private List<IWebElement> elementsList;
        protected List<RowItem> rowValuesList;

        //public CheckoutPage(IWebDriver driver, MainMenuBarPage mainMenuBar) : base(driver)
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            _bar = new MainMenuBarPage(driver);
            _single = CurrentOrderSingle.Instance;
            PageFactory.InitElements(_driver, this);
            elementsList = new List<IWebElement> { ElementContinue };
            WaitForElements(elementsList);
            List<IWebElement> elementsRowList_asList = new List<IWebElement>(ElementsRowList);
            WaitForElements(elementsRowList_asList);
            rnd = new Random();
        }

        [FindsBy(How = How.ClassName, Using = "step2")]
        private IWebElement ElementContinue { get; set; }
        [FindsBy(How = How.CssSelector, Using = "iframe[name='fb_xdm_frame_https']")]
        private IWebElement ElementIFrame { get; set; }
        [FindsBy(How = How.CssSelector, Using = "product_row")]
        private IList<IWebElement> ElementsRowList { get; set; }


        public CheckoutPage ReadValues()
        {
            rowValuesList = new List<RowItem>();
            foreach (IWebElement row in ElementsRowList)
            {
                rowValuesList.Add(new RowItem(row));
            }
            foreach (RowItem oneRow in rowValuesList)
            {
                Console.WriteLine(oneRow);
            }
            return this;
        }

        public CheckoutPage CompareOrders()
        {
            bool isEquals = true;
            int index = 0;
            if (_single.CurrentOrder.Size() == rowValuesList.Count)
            {
                for (int i = 0; i < _single.CurrentOrder.Size(); i++)
                {
                    if (isEquals)
                    {
                        isEquals = _single.CurrentOrder.GetProd(i).GetName().Equals(rowValuesList[i].Name)
                        && _single.CurrentOrder.GetProd(i).GetPrice().Equals(rowValuesList[i].Price)
                        && _single.CurrentOrder.GetProd(i).GetTotalProductPrice().Equals(rowValuesList[i].PriceTotal);
                        //index = i;
                    }
                    else
                    {
                        GetType().Name.Log( "elementy są rowne ", _single.CurrentOrder.GetProd(index).GetName() + " równe " + rowValuesList[index].Name);
                    }
                }
            }
            else
            {
                GetType().Name.Log("inne rozmiary to źle", "WRONG");
            }
            return this;
        }

        public CheckoutPage ContinueClick()
        {
            ClickElement(ElementContinue);
            GetType().Name.Log("Click Continue after check order", "True");
            return this;
        }

    }
}
