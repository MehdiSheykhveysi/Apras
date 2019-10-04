using App01.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App02.Contract.Contracts.Common
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        DbSet<TEntity> Entities { get; set; }
        IQueryable<TEntity> NoTrackEntities { get; }
        IQueryable<TEntity> TrackEntities { get; }
        
        Task<TEntity> GetByIdAsync(object ID, CancellationToken CancellationToken);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
