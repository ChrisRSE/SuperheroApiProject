using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperheroApi.Models
{
    public class SuperheroContext : DbContext
    {
        public SuperheroContext(DbContextOptions<SuperheroContext> options)
            : base(options)
        {
        }

        public DbSet<SuperheroItem> SuperheroItems { get; set; }
    }
}
