using EComerceSytem.AbstractTypes;
using EComerceSytem.ConcreateTypes;
using EComerceSytem.Logic;
using EComerceSytem.Logic.MainLogic;
using EComerceSytem.Users;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EComerceSytem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var cheese = new Chesse
            {
                Name = "Cheddar Cheese",
                Price = 50,
                Quantity = 10,
                ExpireDate = DateTime.Now.AddDays(10),
                Wieght = 2
            };

            var biscuits = new Biscuits
            {
                Name = "Oreo",
                Price = 30,
                Quantity = 20,
                ExpireDate = DateTime.Now.AddDays(5)
            };

            var tv = new TV
            {
                Name = "Samsung Smart TV",
                Price = 5000,
                Quantity = 5,
                Wieght = 20
            };

            var card = new MobileScratchCard
            {
                Name = "Etisalat Scratch Card",
                Price = 10,
                Quantity = 50
            };

            var cart = new Cart();

            var logger = new LoggerService();
            var admin = new AdminNotifier();
            var inventory = new InventoryService();
            var qc = new QualityControl();

            cart.CheckoutExceptionOccurred += logger.HandleException;
            cart.CheckoutExceptionOccurred += admin.HandleException;
            cart.CheckoutExceptionOccurred += inventory.HandleException;
            cart.CheckoutExceptionOccurred += qc.HandleException;

            var customer = new Customer
            {
                Name = "Mark",
                Balance = 10000,
                Card = cart
            };

            try
            {
                cart.AddProduct(cheese, 2);      
                cart.AddProduct(biscuits, 1);    
                cart.AddProduct(tv, 1);          
                cart.AddProduct(card, 3);        

                cart.CheckOut(customer);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Checkout failed: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
