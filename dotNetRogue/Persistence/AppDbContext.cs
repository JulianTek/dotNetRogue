using System.Threading;
using System.Threading.Tasks;
using dotNetRogue.Application.Database;
using dotNetRogue.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetRogue.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Enemy> Enemies { get; set; }
    }
}
