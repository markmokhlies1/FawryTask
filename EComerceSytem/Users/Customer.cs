using EComerceSytem.Logic.MainLogic;

namespace EComerceSytem.Users
{
    public class Customer
    {
        public string Name { get; set; }
        public decimal Balance {  get; set; }
        public Cart Card { get; set; }
    }
}
