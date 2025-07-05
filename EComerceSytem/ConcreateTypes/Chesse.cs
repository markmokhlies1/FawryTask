using EComerceSytem.AbstractTypes;

namespace EComerceSytem.ConcreateTypes
{
    public class Chesse : Product, IExpireation, IShippible
    {
        public DateTime ExpireDate { get ; set ; }
        public decimal Wieght { get; set; }

        public string GetName()
        {
            return Name;
        }

        public decimal GetWeight()
        {
            return Wieght;
        }
    }
}
