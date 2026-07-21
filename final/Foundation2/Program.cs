using System;

namespace OnlineOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
            Address address2 = new Address("45 Maple Ave", "Toronto", "ON", "Canada");
            Address address3 = new Address("789 Oak Ln", "Austin", "TX", "United States");

            // Create customers
            Customer customer1 = new Customer("John Doe", address1);
            Customer customer2 = new Customer("Jane Smith", address2);
            Customer customer3 = new Customer("Bob Johnson", address3);

            // Create orders
            Order order1 = new Order(customer1);
            Order order2 = new Order(customer2);
            Order order3 = new Order(customer3);

            // Add products to orders
            order1.AddProduct(new Product("Laptop", 101, 999.99, 1));
            order1.AddProduct(new Product("Mouse", 102, 29.99, 2));
            order1.AddProduct(new Product("USB Cable", 103, 12.99, 3));

            order2.AddProduct(new Product("Headphones", 201, 79.99, 1));
            order2.AddProduct(new Product("Phone Case", 202, 24.99, 2));

            order3.AddProduct(new Product("Monitor", 301, 299.99, 1));
            order3.AddProduct(new Product("Keyboard", 302, 89.99, 1));
            order3.AddProduct(new Product("Webcam", 303, 59.99, 1));

            // Display order info
            DisplayOrderInfo(order1, "Order #1");
            DisplayOrderInfo(order2, "Order #2");
            DisplayOrderInfo(order3, "Order #3");
        }

        static void DisplayOrderInfo(Order order, string orderNumber)
        {
            Console.WriteLine("\n" + orderNumber);
            Console.WriteLine(new string('-', 40));
            
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            
            Console.WriteLine("Total Price: $" + order.GetTotalPrice().ToString("F2"));
            Console.WriteLine(new string('-', 40));
        }
    }
}