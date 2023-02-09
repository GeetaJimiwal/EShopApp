using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketApi.Repository.City
{
   public interface ICityRepository
    {
        Model.City GetById(int id);
        List<Model.City> GetAll();
        Model.City Create(Model.City city);
    }
}
