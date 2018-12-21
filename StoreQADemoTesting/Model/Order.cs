using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Model
{
    public class Order
    {
        private List<Product> orderList;
        private decimal shippingPirce;

        public Order()
        {
            orderList = new List<Product>();
        }

        public void AddProduct(Product prod)
        {
            if (orderList.Count == 0 || !IfContains(prod))
            {
                prod.AddQuantity();
                orderList.Add(prod);
            }

        }

        private bool IfContains(Product product)
        {
            bool flag = false;
            int i = 0;
            while (!flag && i < orderList.Count)
            {
                if (product.GetName().Equals(orderList[i].GetName()))
                {
                    orderList[i].AddQuantity();
                    flag = true;
                }
                i++;
            }
            return flag;
        }

        public int GetAmount()
        {
            int amount = 0;
            foreach (Product p in orderList)
            {
                amount += p.GetQuantity();
            }
            return amount;
        }

        public int Size()
        {
            return orderList.Count;
        }

        public Product GetProd(int i)
        {
            return orderList[i];
        }

        public decimal GetShippingPrice()
        {
            return shippingPirce;
        }

        public decimal GetTotalOrderPrice()
        {
            decimal result = new decimal(0);
            foreach (Product p in orderList)
            {
                result += p.GetPrice() * (new decimal(p.GetQuantity()));
                //result.Add(p.GetPrice().Multiply(new BigDecimal(p.GetQuantity()))); kod z javy dla porównania, przeciazzanie operatorow rules
            }
            return result;
        }

        public void SetShippingPirce(decimal shippingPirce)
        {
            this.shippingPirce = shippingPirce;
        }

    }
}
