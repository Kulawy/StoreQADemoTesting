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

        public string Browser => ConfigurationManager.AppSettings["browser"] ?? "Chrome";


        public PropertiesFilesReader()
        {
        }

        public String GetBrowser()
        {
            //var appSettings = ConfigurationManager.AppSettings["targetBrowser"].ToString();

            //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //var clientBrowser = config.AppSettings.Settings["browser"].Value;
            return ConfigurationManager.AppSettings["browser"] ?? "Chrome";
        }

        public String GetUrl()
        {
            return ConfigurationManager.AppSettings["url"] ?? "http://google.com";
        }

    }
}
