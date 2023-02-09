using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketApi.Db
{
    public class MovieContext  :DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
   : base(options)
        {
        }

        public DbSet<Model.City> City { get; set; }
        public DbSet<Model.Movie> Movie { get; set; }
        public DbSet<Model.State> State { get; set; }
    }
}
