using System;
using System.Linq;


namespace Rest_Api.Models

{
    public static class DbInitializer
    {
        public static void Initialize(OrdersContext context)
        {

            context.Database.EnsureCreated();

 
            var products = new Assortment[]
            {
                new Assortment { ProductCode = "P001", Name = "Продукт 1", PricePerWeight = 10.00m },
                new Assortment { ProductCode = "P002", Name = "Продукт 2", PricePerWeight = 15.00m },
                new Assortment { ProductCode = "P003", Name = "Продукт 3", PricePerWeight = 20.00m },
                new Assortment { ProductCode = "P004", Name = "Продукт 4", PricePerWeight = 10.00m },
                new Assortment { ProductCode = "P005", Name = "Продукт 5", PricePerWeight = 15.00m },
                new Assortment { ProductCode = "P006", Name = "Продукт 6", PricePerWeight = 20.00m },
                new Assortment { ProductCode = "P007", Name = "Продукт 7", PricePerWeight = 10.00m },
                new Assortment { ProductCode = "P008", Name = "Продукт 8", PricePerWeight = 15.00m },
                new Assortment { ProductCode = "P009", Name = "Продукт 9", PricePerWeight = 20.00m },
                new Assortment { ProductCode = "P0010", Name = "Продукт 10", PricePerWeight = 10.00m },
                new Assortment { ProductCode = "P0011", Name = "Продукт 11", PricePerWeight = 15.00m },
                new Assortment { ProductCode = "P0012", Name = "Продукт 12", PricePerWeight = 20.00m },
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            var orders = new OrdersRegistration[]
            {
                new OrdersRegistration { Customer = "Компания A", ProductCode = "P001", ProductName = "Продукт 1", Weight = 5, OrderDate = DateTime.Now.AddDays(-1), OrderCost = 50.00m },
                new OrdersRegistration { Customer = "Компания B", ProductCode = "P002", ProductName = "Продукт 2", Weight = 3, OrderDate = DateTime.Now, OrderCost = 45.00m },
                new OrdersRegistration { Customer = "Компания C", ProductCode = "P003", ProductName = "Продукт 3", Weight = 2, OrderDate = DateTime.Now.AddDays(1), OrderCost = 40.00m },
                new OrdersRegistration { Customer = "Компания D", ProductCode = "P004", ProductName = "Продукт 4", Weight = 5, OrderDate = DateTime.Now.AddDays(-1), OrderCost = 50.00m },
                new OrdersRegistration { Customer = "Компания E", ProductCode = "P005", ProductName = "Продукт 5", Weight = 3, OrderDate = DateTime.Now, OrderCost = 45.00m },
                new OrdersRegistration { Customer = "Компания F", ProductCode = "P006", ProductName = "Продукт 6", Weight = 2, OrderDate = DateTime.Now.AddDays(1), OrderCost = 40.00m },
                new OrdersRegistration { Customer = "Компания G", ProductCode = "P007", ProductName = "Продукт 7", Weight = 5, OrderDate = DateTime.Now.AddDays(-1), OrderCost = 50.00m },
                new OrdersRegistration { Customer = "Компания H", ProductCode = "P008", ProductName = "Продукт 8", Weight = 3, OrderDate = DateTime.Now, OrderCost = 45.00m },
                new OrdersRegistration { Customer = "Компания I", ProductCode = "P009", ProductName = "Продукт 9", Weight = 2, OrderDate = DateTime.Now.AddDays(1), OrderCost = 40.00m },
                new OrdersRegistration { Customer = "Компания J", ProductCode = "P0010", ProductName = "Продукт 10", Weight = 5, OrderDate = DateTime.Now.AddDays(-1), OrderCost = 50.00m },
                new OrdersRegistration { Customer = "Компания K", ProductCode = "P0011", ProductName = "Продукт 11", Weight = 3, OrderDate = DateTime.Now, OrderCost = 45.00m },
                new OrdersRegistration { Customer = "Компания L", ProductCode = "P0012", ProductName = "Продукт 12", Weight = 2, OrderDate = DateTime.Now.AddDays(1), OrderCost = 40.00m }
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
