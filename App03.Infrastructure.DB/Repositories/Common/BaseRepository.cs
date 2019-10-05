using App00.Common.Attributes;
using App00.Common.Extensions;
using App01.Domain.Entities.Common;
using App02.Contract.Contracts.Common;
using App03.Infrastructure.DB.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace App03.Infrastructure.DB.Repositories
{
    [ServiceMark]
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly AprasContext _aprasContext;

        public DbSet<TEntity> Entities { get; set; }

        public BaseRepository(AprasContext aprasContext)
        {
            _aprasContext = aprasContext;
            Entities = _aprasContext.Set<TEntity>();
        }
        public IQueryable<TEntity> NoTrackEntities => Entities.AsNoTracking();

        public IQueryable<TEntity> TrackEntities => Entities;

        public virtual Task<TEntity> GetByIdAsync(object ID, CancellationToken CancellationToken)
        {
            return Entities.FindAsync(new object[] { ID }, CancellationToken);
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (Assert.NotNull(entity))
            {
                await Entities.AddAsync(entity, cancellationToken);
                await SaveChangesAsync(cancellationToken);
            }
        }
        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (Assert.NotNull(entity))
            {
                Entities.Update(entity);
                if (_aprasContext.Entry(entity).State == EntityState.Detached)
                    Attach(entity);
                await SaveChangesAsync(cancellationToken);
            }
        }
        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (Assert.NotNull(entity))
            {
                if (_aprasContext.Entry(entity).State == EntityState.Detached)
                    Attach(entity);
                Entities.Remove(entity);
                await SaveChangesAsync(cancellationToken);
            }
        }

        public virtual async Task LoadCollectionAsync<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression, CancellationToken cancellationToken) where TProperty : class
        {
            this.Attach(entity);
            var collection = _aprasContext.Entry(entity).Collection(propertyExpression);
            if (!collection.IsLoaded)
                await collection.LoadAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task LoadRefrenceAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression, CancellationToken cancellationToken) where TProperty : class
        {
            this.Attach(entity);
            var refrence = _aprasContext.Entry(entity).Reference(propertyExpression);
            if (!refrence.IsLoaded)
                await refrence.LoadAsync(cancellationToken).ConfigureAwait(true);
        }

        public virtual void Attach(TEntity entity)
        {
            if (Assert.NotNull(entity))
                if (_aprasContext.Entry(entity).State == EntityState.Detached)
                    _aprasContext.Attach(entity);
        }

        private async Task SaveChangesAsync(CancellationToken cancellationToken) => await _aprasContext.SaveChangesAsync(cancellationToken);
    }
}
