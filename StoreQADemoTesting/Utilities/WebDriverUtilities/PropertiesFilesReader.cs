using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //protected Properties _prop;

        public PropertiesFilesReader()
        {
            data = new Dictionary<string, string>();
            //_input = new StreamReader(RELATIVE_PATH)
            //using (_input = new StreamReader(RELATIVE_PATH))
            //{
            //    foreach (var row in File.ReadAllLines(PATH_TO_FILE))
            //        data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
            //    _prop = new Properties();
            //    _prop.load(_input);
            //}
            Console.WriteLine(RELATIVE_PATH3);
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

    }
}
