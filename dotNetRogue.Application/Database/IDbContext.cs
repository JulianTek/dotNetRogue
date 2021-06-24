using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace dotNetRogue.Application.Database
{
    public interface IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        // EntityEntry Entry(object entity);

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
