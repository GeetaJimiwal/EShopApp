using Microsoft.EntityFrameworkCore;
using MovieTicketApi.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketApi.Repository.State
{
    public class StateRepository : IStateRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.State> entities;

        public StateRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Model.State>();
        }

        public Model.State Create(Model.State state)
        {   
            throw new NotImplementedException();
        }

        public List<Model.State> GetAll()
        {
            return this.entities.AsQueryable().ToList();
        }

        public Model.State GetById(int id)
        {
            return entities.Find(id);
        }
    }
}
