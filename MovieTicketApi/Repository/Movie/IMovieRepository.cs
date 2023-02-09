using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketApi.Repository.Movie
{
   public interface IMovieRepository
    {
        Model.Movie GetById(int id);
        List<Model.Movie> GetAll();
        Model.Movie Create(Model.Movie movie);
    }
}
