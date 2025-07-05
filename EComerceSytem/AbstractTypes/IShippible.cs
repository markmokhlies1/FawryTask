namespace EComerceSytem.AbstractTypes
{
    public interface IShippible 
    {
        string GetName();
        decimal GetWeight();
        public decimal Wieght {  get; set; }
    }
}
