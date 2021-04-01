using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogue.Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetRogue
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Enemy> Enemies { get; set; }
    }
}
