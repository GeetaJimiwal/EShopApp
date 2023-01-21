using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ECOMMERCEAPP.Repository
{
    public interface IProductRepository
    {
        Model.Product GetById(int id);
        List<Model.Product> GetAll();
        Model.Product Create(Model.Product product);
    }
}
