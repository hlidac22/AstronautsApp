using AstronautsDataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstronautsDataLibrary.Db
{
    public class AstronautsContext : DbContext
    {
        public AstronautsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Astronaut> Astronauts { get; set; }
        public DbSet<Superpower> Superpowers { get; set; }
    }
}
