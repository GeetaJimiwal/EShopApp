using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Db;
using WebApplication1.EntityModel;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : Controller
    {
        private readonly ICartItemService cartItemService;
        private readonly IMapper mapper;
        private readonly IProductService productService;

        public CartItemController(ICartItemService cartItemService, IMapper mapper, IProductService productService)
        {
            this.cartItemService = cartItemService;
            this.mapper = mapper;
            this.productService = productService;
        }
        [HttpGet]
        public IEnumerable<CartItemEntity> GetAll()
        {
            var carts = cartItemService.GetAll();
            var cartEntity = mapper.Map<List<CartItemEntity>>(carts);
            return cartEntity;
        }
        [HttpGet("{id}")]
        public List<CartItemEntity> Get(int id)
        {
            var cartById = new List<CartItemEntity>();
            var carts = cartItemService.GetAll();
            var cartEntity = mapper.Map<List<CartItemEntity>>(carts);
            foreach (var cart in cartEntity)
            {
                if (cart.ProductId == id)
                {
                    cartById.Add(cart);
                }
            }
            return cartById;
        }
        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        public IResult cart(CartItemEntity cartItemEntity)
        {
            try
            {
                var data = cartItemService.GetById(cartItemEntity.ProductId);
                var catitemsummry = mapper.Map<CartItem>(cartItemEntity);
                if (data != null)
                { 
                    var cartitemview = cartItemService.Update(catitemsummry);
                }
                else
                {
                    var cartitemview = cartItemService.Create(catitemsummry); 
                }
                if (catitemsummry != null)
                {
                    return Results.Ok(cartItemEntity.ProductId);
                }
                return Results.BadRequest();
            }
            catch (Exception e)

            {
                throw;
            }


        }
      
        /* public IEnumerable<CartItemEntity> UpdateProduct(CartItem cartItem)
         {

             var cartsUpdate = cartItemService.Update(cartItem);
             var cartEntityupdate = mapper.Map<List<CartItem>>(cartsUpdate);
             return cartEntityupdate;
         }*/
        [HttpPut]
        public CartItem UpdateProduct(CartItem cartItem)
        {

            var cartsdelete = cartItemService.Update(cartItem);
            return cartsdelete;

        }

        [HttpDelete("{id}")]
        public CartItem delete(int id)
        {
             
            var cartsdelete = cartItemService.DeleteProduct(id);
            return cartsdelete;

        }

        /*public async Task<CartItemEntity> DeleteProduct(int id)
        {
            var cartById = new List<CartItemEntity>();
            var cartsdelete = cartItemService.DeleteProduct(id);
            var cartEntityDelete = mapper.Map<List<CartItem>>(cartsdelete);
            return cartEntityDelete;
        }*/
    }
}
 
