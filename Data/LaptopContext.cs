using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Laptop.Models;

namespace Laptop.Data
{
    public class LaptopContext : DbContext
    {
        public LaptopContext (DbContextOptions<LaptopContext> options)
            : base(options)
        {
        }

        public DbSet<Laptop.Models.Brand> Brand { get; set; } = default!;

        public DbSet<Laptop.Models.Laptop> Laptop { get; set; }
    }
}
