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
        private static readonly object _lock = new object();

        public static string ParseStringToComparableValue(this string inputString)
        {
            return inputString.Replace(" ", "").Replace("-", "").Replace("–", "");
        }

        public static decimal FormPriceToBigDecimal(this string text)
        {
            decimal price = new decimal(Double.Parse(text.Replace("$", "").Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture)); //System.Globalization.CultureInfo.InvariantCulture
            return price;
        }

        public static string GetRandomString(this string text, int length)
        {
            lock (_lock)
            {
                Thread.Sleep(60);
                var random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }

        }

        public static string RandomStringOfLength5(this string text)
        {
            var rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());

        }

        public static void Log(this string where, String description, String value)
        {
            Console.WriteLine("Log :" + where + " - " + description + " - " + value);
        }

    }
}
