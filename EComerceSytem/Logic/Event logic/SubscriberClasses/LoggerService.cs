namespace EComerceSytem.Logic
{
    public class LoggerService
    {
        public void HandleException(object sender, CheckoutExceptionEventArgs e)
        {
            Console.WriteLine($"[Logger] {e.Exception.GetType().Name}: {e.Exception.Message} Context: {e.ContextMessage}");
        }
    }
}
