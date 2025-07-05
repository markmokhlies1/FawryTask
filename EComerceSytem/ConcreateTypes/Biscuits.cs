using EComerceSytem.AbstractTypes;

namespace EComerceSytem.ConcreateTypes
{
    public class Biscuits : Product,IExpireation
    {
        public DateTime ExpireDate { get; set; }
    }
}
