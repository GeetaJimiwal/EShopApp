using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketApi.Repository.State
{
    public interface IStateRepository
    {
        Model.State GetById(int id);
        List<Model.State> GetAll();
        Model.State Create(Model.State state);
    }
}
