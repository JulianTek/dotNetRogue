using System;
using System.Collections.Generic;
using System.Text;
using dotNetRogue.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetRogue.Application.Database
{
    public interface IAppDbContext : IDbContext
    {
        public DbSet<Enemy> Enemies { get; set; }
    }
}
