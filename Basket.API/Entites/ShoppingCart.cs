namespace Basket.API.Entites
{
    public class ShoppingCart
    {
        public string Username { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> CartItems { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart()
        {

        }

        public ShoppingCart(string username)
        {
            Username = username;
        }


        public int TotalItems
        {
            get => CartItems.Count;
           
        }


        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = decimal.Zero;
                foreach (ShoppingCartItem item in CartItems)
                {
                    decimal itemTotal = item.Price * item.Quantity;
                    totalPrice = totalPrice + itemTotal;
                }
                return totalPrice;
            }
        }

    }
}
