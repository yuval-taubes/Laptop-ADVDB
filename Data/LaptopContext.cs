using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Laptop.Models;
using System.Runtime.ConstrainedExecution;

namespace Laptop.Data
{
    public class LaptopContext : DbContext
    {
        public DbSet<Laptop.Models.Brand> Brand { get; set; } = default!;

        public DbSet<Laptop.Models.LaptopObject> Laptop { get; set; }

        public LaptopContext (DbContextOptions<LaptopContext> options)
            : base(options)
        {
        }
    }
}
