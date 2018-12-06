using Deveel.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Model
{
    public class Product
    {
        public String name;
        public int Quantity { get; set; }
        public BigDecimal Price { get; }

        public Product(String name, BigDecimal price)
        {
            this.name = name;
            this.Price = price;
        }

        public void AddQuantity()
        {
            Quantity++;
        }

        public String GetName()
        {
            return name;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public BigDecimal GetPrice()
        {
            return Price;
        }

        public BigDecimal GetTotalProductPrice()
        {
            return Price * new BigDecimal(Quantity);
        }

        
    public override bool Equals(Object obj)
        {
            Product prod = (Product)obj;
            if (name.Equals(prod.name) && Price == prod.Price)
                return true;
            else
                return false;
        }

        
    public override String ToString()
        {
            return name + " " + Price + " quantity: " + Quantity;
        }



    }
}
