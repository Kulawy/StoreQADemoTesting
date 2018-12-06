using Deveel.Math;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Model
{
    public class RowItem
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public BigDecimal Price { get; set; }
        public BigDecimal PriceTotal { get; set; }

        public RowItem(IWebElement tr)
        {
            List<IWebElement> columnsTD = new List<IWebElement>(tr.FindElements(By.CssSelector("td"))); 
            this.Name = columnsTD[1].Text;
            //this.quantity = columnsTD.get(1).getText();
            IWebElement form = columnsTD[2];
            IWebElement quantityInput = form.FindElement(By.Name("quantity"));
            this.Quantity = Int32.Parse(quantityInput.GetAttribute("value"));
            this.Price = new BigDecimal(Double.Parse(columnsTD[3].Text.Replace("$", "")));
            this.PriceTotal = new BigDecimal(Double.Parse(columnsTD[4].Text.Replace("$", "").Replace(",", "")));

        }

        public override String ToString()
        {
            return "Row value: " + Name + " " + Quantity + " " + Price + " " + PriceTotal;
        }

    }
}
