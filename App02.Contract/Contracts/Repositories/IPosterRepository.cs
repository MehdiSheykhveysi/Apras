using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App01.Domain.Entities;
using App02.Contract.Contracts.Common;
using App02.Contract.Contracts.DTOs;
using App02.Contract.Resource;

namespace App03.Infrastructure.DB.Repositories
{
    public interface IPosterRepository : IBaseRepository<Poster>
    {
        Task<IEnumerable<IPosterPagedDto>> GetPagedPosteAsync(string SerackKeyInTitle, IPaginationInfo pagination, CancellationToken cancellationToken, bool IsLoadDeleteditems = false);
    }
}