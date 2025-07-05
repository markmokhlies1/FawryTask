using EComerceSytem.AbstractTypes;

namespace EComerceSytem.ConcreateTypes
{
    public class TV : Product, IShippible
    {
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
