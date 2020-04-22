using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class StuffContext : DbContext
    {
        public StuffContext(DbContextOptions<StuffContext> options)
            : base(options)
        {
        }
        public DbSet<Stuff> Stuff { get; set; }
        public DbSet<File> File { get; set; }
    }
}
