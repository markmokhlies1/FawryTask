using EComerceSytem.AbstractTypes;

namespace EComerceSytem.Logic.MainLogic
{
    public static class ShippingService
    {
        public static decimal Ship(List<Product> products)
        {
            var shippableItems = products
                .OfType<IShippible>()
                .Cast<IShippible>()
                .ToList();

            if (shippableItems.Count == 0) return 0;

            Console.WriteLine("** Shipment notice **");

            var grouped = shippableItems
                .GroupBy(p => p.GetName())
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count(),
                    TotalWeight = g.Sum(i => i.GetWeight())
                });

            decimal totalWeight = 0;

            foreach (var item in grouped)
            {
                Console.WriteLine($"{item.Count}x {item.Name} {item.TotalWeight * 1000}g");
                totalWeight += item.TotalWeight;
            }

            Console.WriteLine($"Total package weight {totalWeight}kg");

            return totalWeight * 0.5m; 
        }
    }
}
