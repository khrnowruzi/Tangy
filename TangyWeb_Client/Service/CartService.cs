using Blazored.LocalStorage;
using Tangy_Common;
using TangyWeb_Client.Service.IService;
using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Service
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;

        public CartService(ILocalStorageService localStorage)
        {
            this._localStorage = localStorage;
        }

        public async Task IncrementCart(ShoppingCart cartToAdd)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);
            bool itemInCart = false;

            if (cart == null)
            {
                cart = new List<ShoppingCart>();
            }
            foreach (var obj in cart)
            {
                if (obj.ProductId == cartToAdd.ProductId && obj.ProductPriceId == cartToAdd.ProductPriceId)
                {
                    itemInCart = true;
                    obj.Count += cartToAdd.Count;
                }
            }
            if (!itemInCart)
            {
                cart.Add(new ShoppingCart()
                {
                    ProductId = cartToAdd.ProductId,
                    ProductPriceId = cartToAdd.ProductPriceId,
                    Count = cartToAdd.Count
                });
            }
            await _localStorage.SetItemAsync(SD.ShoppingCart, cart);
        }

        public async Task DecrementCart(ShoppingCart cartToDecrement)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);

            if (cart != null)
            {
                var foundedShopingCart = cart
                    .Where(c => c.ProductId == cartToDecrement.ProductId && c.ProductPriceId == cartToDecrement.ProductId)
                    .FirstOrDefault();

                if (foundedShopingCart != null && cartToDecrement.Count <= foundedShopingCart.Count)
                {
                    if (cartToDecrement.Count == foundedShopingCart.Count)
                    {
                        cart.Remove(foundedShopingCart);
                    }
                    else
                    {
                        foundedShopingCart.Count -= cartToDecrement.Count;
                    }

                    await _localStorage.SetItemAsync(SD.ShoppingCart, cart);
                }
            }
        }
    }
}
