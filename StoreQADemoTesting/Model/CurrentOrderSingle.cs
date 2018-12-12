using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Model
{
    public sealed class CurrentOrderSingle
    {
        private static CurrentOrderSingle _oInstance = null;
        //private readonly int _nCouter = 0;

        public Order CurrentOrder { get; set; }

        private CurrentOrderSingle()
        {
            //_nCouter = 1;
            CurrentOrder = new Order();
        }

        public static CurrentOrderSingle Instance
        {
            get
            {
                if ( _oInstance == null)
                {
                    _oInstance = new CurrentOrderSingle();
                }
                return _oInstance;
            }

        }



    }
}
