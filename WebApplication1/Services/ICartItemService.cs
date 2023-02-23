using WebApplication1.Model;
namespace WebApplication1.Services

{
    public interface ICartItemService
    {
        CartItem GetById(int id);
        List<CartItem> GetAll();
        CartItem Update(CartItem cartItem);
        CartItem Create(CartItem cartItem);
        CartItem DeleteProduct(int id);
    }
}
