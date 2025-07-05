using EComerceSytem.AbstractTypes;
using EComerceSytem.Exceptions;
using EComerceSytem.Users;

namespace EComerceSytem.Logic.MainLogic
{
    public class Cart
    {
        #region Prop
        public List<CartItem> Items { get; private set; } = new();
        #endregion

        #region Functions
        public void AddProduct(Product product, int quantity)
        {
            if (quantity > product.Quantity)
            {
                var ex = new OutOfStockException($"Not enough stock for {product.Name}");
                OnCheckoutException(ex, product);
                throw ex;
            }

            var existingItem = Items.FirstOrDefault(i => i.Product == product);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { Product = product, Quantity = quantity });
            }

            product.Quantity -= quantity;
        }
        public void CheckOut(Customer customer)
        {
            try
            {


                if (IsEmpty())
                {
                    throw new EmptyCartException("Cart is empty.");
                }

                decimal subTotal = 0;
                List<IShippible> shippableItems = new();

                foreach (var item in Items)
                {
                    var product = item.Product;
                    int count = item.Quantity;

                    if (product is IExpireation exp && DateTime.Now > exp.ExpireDate)
                    {
                        throw new ExpiredProductException($"{product.Name} is expired.");
                    }

                    subTotal += product.Price * count;

                    if (product is IShippible ship)
                    {
                        for (int i = 0; i < count; i++)
                            shippableItems.Add(ship);
                    }
                }

                decimal shippingCost = ShippingService.Ship(shippableItems.Cast<Product>().ToList());
                decimal total = subTotal + shippingCost;

                if (customer.Balance < total)
                {
                    throw new InsufficientBalanceException("Customer does not have enough balance.");
                }
                Console.WriteLine();
                Console.WriteLine("** Checkout receipt **");
                foreach (var item in Items)
                {
                    Console.WriteLine($"{item.Quantity}x {item.Product.Name} {item.Quantity * item.Product.Price}");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("----------------------");
                Console.WriteLine($"Subtotal {subTotal}");
                Console.WriteLine($"Shipping {shippingCost}");
                Console.WriteLine($"Amount {total}");

                customer.Balance -= total;
                Clear();
            }
            catch (Exception ex)
            {
                var failedItem = Items.LastOrDefault()?.Product;
                OnCheckoutException(ex, failedItem, "Checkout Failed");
                throw;
            }
        }
        private void Clear()
        {
            Items.Clear();
        }
        private bool IsEmpty()
        {
            return Items.Count == 0;
        }
        #endregion

        #region Event
        public event EventHandler<CheckoutExceptionEventArgs> CheckoutExceptionOccurred;
        protected virtual void OnCheckoutException(Exception ex, Product product = null, string context = null)
        {
            CheckoutExceptionOccurred?.Invoke(this, new CheckoutExceptionEventArgs
            {
                Exception = ex,
                Product = product,
                ContextMessage = context
            });
        }
        #endregion
    }
}
