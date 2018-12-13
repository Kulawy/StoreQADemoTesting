using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Utilities
{
    public class StringGenerator
    {
        private static readonly object _lock = new object();

        public static string GetRandomString(int length)
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

    }
}
