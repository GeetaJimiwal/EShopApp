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
            CreateMap<Product, ProductEntity>().ReverseMap();

            CreateMap<EntityModel.UserCreadentialEntity, Model.UserCreadential>();

        }
    }
}
