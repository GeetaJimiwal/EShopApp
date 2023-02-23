using AutoMapper;
using WebApplication1.EntityModel;
using WebApplication1.Model;

namespace WebApplication1.MapperProfile
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<ProductEntity,Product>().ReverseMap();
            CreateMap<LoginRequest, LoginRequestEntity>().ReverseMap();
            CreateMap<EntityModel.UserCreadentialEntity, Model.UserCreadential>().ReverseMap();
            CreateMap<EntityModel.CartItemEntity, Model.CartItem>();
            CreateMap<CartItem,CartItemEntity >();
            CreateMap<EntityModel. CategoryEntity, Model.Category>().ReverseMap();

        }
    }
}
