using EComerceSytem.AbstractTypes;

namespace EComerceSytem.Logic
{
    public class CheckoutExceptionEventArgs : EventArgs
    {
        public Exception Exception { get; set; }
        public Product Product { get; set; }
        public string ContextMessage { get; set; }
    }
}
