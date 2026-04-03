using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        // --- PEDIDO 1: Cliente en Perú (Chincha) ---
            Address address1 = new Address("Av. Benavides 123", "Chincha", "Ica", "Peru");
            Customer customer1 = new Customer("Abel Nonato", address1);
            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Teclado Mecánico", "K-100", 45.50m, 1));
            order1.AddProduct(new Product("Mouse Gamer", "M-200", 25.00m, 2));
        // --- PEDIDO 2: Cliente en USA ---
            Address address2 = new Address("123 Main St", "Rexburg", "ID", "USA");
            Customer customer2 = new Customer("John Doe", address2);
            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("C# Programming Book", "B-500", 59.99m, 1));
            DisplayOrderDetails(order1);
            Console.WriteLine("\n" + new string('-', 40) + "\n");
            DisplayOrderDetails(order2);
        }
        static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():0.00}");
        }
    }