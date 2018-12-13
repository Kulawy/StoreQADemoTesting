using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Model
{
    public sealed class CurrentOrderHolderSingleton
    {
        private static CurrentOrderHolderSingleton _oInstance = null;
        //private readonly int _nCouter = 0;

        public Order CurrentOrder { get; set; }

        private CurrentOrderHolderSingleton()
        {
            //_nCouter = 1;
            CurrentOrder = new Order();
        }

        public static CurrentOrderHolderSingleton Instance
        {
            get
            {
                if ( _oInstance == null)
                {
                    _oInstance = new CurrentOrderHolderSingleton();
                }
                return _oInstance;
            }

        }



    }
}
