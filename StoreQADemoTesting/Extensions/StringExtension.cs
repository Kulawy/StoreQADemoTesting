using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreQADemoTesting.MyClassExtensions
{
    public static class StringExtension
    {
        
        public static string ParseStringToComparableValue(this string inputString)
        {
            return inputString.Replace(" ", "").Replace("-", "").Replace("–", "");
        }

        public static decimal FormPriceToDecimal(this string text)
        {
            decimal price = new decimal(Double.Parse(text.Replace("$", "").Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture)); //System.Globalization.CultureInfo.InvariantCulture
            return price;
        }

        

        

        public static void Log(this string where, String description, String value)
        {
            Console.WriteLine("Log :" + where + " - " + description + " - " + value);
        }

    }
}
