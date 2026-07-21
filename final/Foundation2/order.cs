using System;
using System.Collections.Generic;

namespace OnlineOrderingSystem
{
    // orders
    public class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        private double GetShippingCost()
        {
            if (customer.IsInUSA())
            {
                return 5.0;  // Cheap shipping for domestic homies
            }
            else
            {
                return 35.0;  // International shipping hurts the wallet
            }
        }

        public double GetTotalPrice()
        {
            double total = 0.0;
            
            foreach (Product product in products)
            {
                total += product.GetTotalCost();
            }
            
            total += GetShippingCost();
            return total;
        }

        public string GetPackingLabel()
        {
            string label = "=== PACKING LABEL ===\n";
            label += "Items in this order:\n";
            
            foreach (Product product in products)
            {
                label += "- " + product.Name + " (ID: " + product.ProductId + ") x " + product.Quantity + "\n";
            }
            
            return label;
        }

        public string GetShippingLabel()
        {
            string label = "=== SHIPPING LABEL ===\n";
            label += "To: " + customer.Name + "\n";
            label += "Address:\n";
            label += customer.Address.GetFullAddress();
            
            return label;
        }
    }
}