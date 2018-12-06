using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using StoreQADemoTesting.Model;
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

        public CheckoutPage(IWebDriver driver, MainMenuBarPage mainMenuBar) : base(driver)
        {
            _bar = mainMenuBar;
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


        public CheckoutPage readValues()
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

        public CheckoutPage compareOrders()
        {
            bool isEquals = true;
            int index = 0;
            if (_bar.CurrentOrder.Size() == rowValuesList.Count)
            {
                for (int i = 0; i < _bar.CurrentOrder.Size(); i++)
                {
                    if (isEquals)
                    {
                        isEquals = _bar.CurrentOrder.GetProd(i).GetName().Equals(rowValuesList[i].Name)
                        && _bar.CurrentOrder.GetProd(i).GetPrice().Equals(rowValuesList[i].Price)
                        && _bar.CurrentOrder.GetProd(i).GetTotalProductPrice().Equals(rowValuesList[i].PriceTotal);
                        //index = i;
                    }
                    else
                    {
                        Log(GetType().Name, "elementy są rowne ", _bar.CurrentOrder.GetProd(index).GetName() + " równe " + rowValuesList[index].Name);
                    }
                }
            }
            else
            {
                Log(GetType().Name, "inne rozmiary to źle", "WRONG");
            }
            return this;
        }

        public CheckoutPage ContinueClick()
        {
            ClickElement(ElementContinue);
            Log(GetType().Name, "Click Continue after check order", "True");
            return this;
        }

    }
}
