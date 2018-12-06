using Deveel.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Utilities
{
    public class MyConverter
    {
        public BigDecimal formPriceToBigDecimal(string text)
        {
            BigDecimal price = new BigDecimal(Double.Parse(text.Replace("$", "").Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture)); //System.Globalization.CultureInfo.InvariantCulture
            return price;
        }

        public String parseStringToComparableValue(String inputString)
        {
            return inputString.Replace(" ", "").Replace("-", "").Replace("–", "");
        }
    }
}
