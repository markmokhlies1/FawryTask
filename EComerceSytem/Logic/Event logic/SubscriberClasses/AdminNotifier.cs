namespace EComerceSytem.Logic
{
    public class AdminNotifier
    {
        public void HandleException(object sender, CheckoutExceptionEventArgs e)
        {
            Console.WriteLine($"[Admin] ALERT: {e.Exception.Message} on product: {e.Product?.Name ?? "Unknown"}");
        }
    }
}
