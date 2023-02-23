using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface ICartItemInterface
    {
        CartItem GetById(int id);
        List<CartItem> GetAll();
        CartItem Create(CartItem cartItem);
        CartItem Update(CartItem cartItem);
        CartItem DeleteProduct(int id);
        CartItem ProductName(CartItem productName);
    }
}
