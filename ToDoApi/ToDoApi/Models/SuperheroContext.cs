using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace SuperheroApi.Models
{
    public class SuperheroContext : DbContext
    {
        public SuperheroContext(DbContextOptions<SuperheroContext> options)
            : base(options)
        {
        }

        public DbSet<SuperheroItem> SuperheroItems { get; set; }

        public DbSet<Result> ResultItems { get; set; }
    }
}
