using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;
using WebApplication1.EntityModel;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Repository
{
    public class CartItemRepository : ICartItemInterface
    {
        private readonly ProductContext dbContext;
        private readonly DbSet<CartItem> cartItems;
        public CartItemRepository(ProductContext dbContext)
        {
            this.dbContext = dbContext;
            this.cartItems = dbContext.Set<CartItem>();
        }

        public CartItem Create(CartItem cartItem)
        {
            dbContext.Add(cartItem);
            dbContext.SaveChanges();
            return cartItem;
        }
        public CartItem Update(CartItem cartItem)
        {
            var getDataByID = GetById(cartItem.ProductId);
            if (getDataByID != null)
            {
                getDataByID.Quantity = cartItem.Quantity + getDataByID.Quantity;
                dbContext.Update(getDataByID);
                dbContext.SaveChanges();

            }
            return GetById(getDataByID.Quantity);
        }
        

        public CartItem Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetAll()
        { 
            return this.cartItems.AsQueryable().ToList();
        }

        public CartItem GetById(int id)
        {
             
            var cardDatabyID = dbContext.CartItem.Where(x => x.ProductId == id).FirstOrDefault();
            return cardDatabyID;
        }

        public CartItem ProductName(CartItem productName)
        {
            throw new NotImplementedException();
        }

      

        public CartItem DeleteProduct(int id)
        {
            var deleteProduct = this.cartItems.Find(id);
            if (deleteProduct != null)
            {
                dbContext.Remove(deleteProduct);
                dbContext.SaveChanges();
            }
            return deleteProduct;
        }
 
         
    }
}
