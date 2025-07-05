using EComerceSytem.Exceptions;

namespace EComerceSytem.Logic
{
    public class InventoryService
    {
        public void HandleException(object sender, CheckoutExceptionEventArgs e)
        {
            if (e.Exception is OutOfStockException)
                Console.WriteLine($"[Inventory] Product out of stock: {e.Product?.Name}");
        }
    }
}
