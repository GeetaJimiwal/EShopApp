using Microsoft.EntityFrameworkCore;
using MovieTicketApi.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketApi.Repository.Movie
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext dbContext;
        private readonly DbSet<Model.Movie> entities;
        public MovieRepository(MovieContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Model.Movie>();
        }
        public Model.Movie Create(Model.Movie movie)
        {
            throw new NotImplementedException();
        }

        public List<Model.Movie> GetAll()
        {
            return this.entities.AsQueryable().ToList();
        }

        public Model.Movie GetById(int id)
        {
            return entities.Find(id);
        }
    }
}
