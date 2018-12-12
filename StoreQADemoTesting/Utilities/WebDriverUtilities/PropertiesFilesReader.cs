using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace StoreQADemoTesting.Utilities.WebDriverUtilities
{
    public class PropertiesFilesReader
    {
        //private static readonly string RELATIVE_PATH = "C:\\Users\\jgeron\\Documents\\dotNetProjects2018\\StoreQADemoTesting\\StoreQADemoTesting\\StoreQADemoTesting\\Resources\\config.properties";
        private static readonly string RELATIVE_PATH2 = "Resources\\config.properties";
        private static readonly string RELATIVE_PATH3 = AppDomain.CurrentDomain.BaseDirectory;
        protected StreamReader _input;
        protected string[] _inputStringArray;
        protected Dictionary<string, string> data;

        public PropertiesFilesReader()
        {
            data = new Dictionary<string, string>();
            Console.WriteLine(RELATIVE_PATH3);                 // <- WriteLine !!!!
            foreach (var row in File.ReadAllLines(RELATIVE_PATH3 + RELATIVE_PATH2))
                    data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));

        }


        public String GetUrl()
        {
            return data["URL"];
        }

        public String GetBrowser()
        {
            return data["Browser"];
        }

        //public String GetBrowser()
        //{
        //    return ConfigurationManager.AppSettings["targetBrowser"].ToString();
        //}

    }
}
