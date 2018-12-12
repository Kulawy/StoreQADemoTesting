using System;

namespace StoreQADemoTesting.Model
{
    public class Product
    {
        public String name;
        public int Quantity { get; set; }
        public decimal Price { get; }

        public Product(String name, decimal price)
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

        public decimal GetPrice()
        {
            return Price;
        }

        public decimal GetTotalProductPrice()
        {
            return Price * new Decimal(Quantity);
        }

        
    public override bool Equals(Object obj)
        {
            Product prod = (Product)obj;
            if (name.Equals(prod.name) && Price == prod.Price)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override String ToString()
        {
            return name + " " + Price + " quantity: " + Quantity;
        }



    }
}
