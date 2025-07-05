using EComerceSytem.Exceptions;

namespace EComerceSytem.Logic
{
    public class QualityControl
    {
        public void HandleException(object sender, CheckoutExceptionEventArgs e)
        {
            if (e.Exception is ExpiredProductException)
                Console.WriteLine($"[QC] Expired product found: {e.Product?.Name}");
        }
    }
}
