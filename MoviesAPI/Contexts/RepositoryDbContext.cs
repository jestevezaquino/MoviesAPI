using Microsoft.EntityFrameworkCore;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Contexts
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
        {

        }
    }
}
