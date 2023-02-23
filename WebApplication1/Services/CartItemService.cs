using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemInterface cartItemInterface;
       
        public CartItemService(ICartItemInterface cartItemInterface)
        {
            this.cartItemInterface = cartItemInterface;
             
        }

        public CartItem Create(CartItem cartItem)
        {
            cartItem = cartItemInterface.Create(cartItem);
            return cartItem;
        }


        public CartItem DeleteProduct(int id)
        {
             var product = cartItemInterface.DeleteProduct(id);
            return product;
        }

        public List<CartItem> GetAll()
        {
             var cart = cartItemInterface.GetAll();
            return cart;
        }

        public CartItem GetById(int id)
        {
             var cart = cartItemInterface.GetById(id);
            return cart;    
        }

        public CartItem Update(CartItem cartItem)
        {
           var cart = cartItemInterface.Update(cartItem);
            return cart;
        }
    }
}
