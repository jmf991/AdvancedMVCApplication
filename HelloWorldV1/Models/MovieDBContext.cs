using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web; 
using System.Data.Entity; 

namespace HelloWorldV1.Models
{
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}