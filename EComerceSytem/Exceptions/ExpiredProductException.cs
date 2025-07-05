namespace EComerceSytem.Exceptions
{
    public class ExpiredProductException : Exception
    {
        public ExpiredProductException(string message) : base(message) { }
    }
}
