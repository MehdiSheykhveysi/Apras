using App00.Common.Attributes;
using App01.Domain.Entities;
using App02.Contract.Contracts.DTOs;
using App02.Contract.Resource;
using App03.Infrastructure.DB.Context;
using App03.Infrastructure.DB.DTOs;
using App03.Infrastructure.DB.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App03.Infrastructure.DB.Repositories
{
    [ServiceMark]
    public class PosterRepository : BaseRepository<Poster>, IPosterRepository
    {
        public PosterRepository(AprasContext context) : base(context)
        {

        }

        public async Task<IEnumerable<IPosterPagedDto>> GetPagedPosteAsync(string SerackKeyInTitle, IPaginationInfo pagination, CancellationToken cancellationToken, bool IsLoadDeleteditems = false)
        {
            return await NoTrackEntities.Where(c => string
            .IsNullOrEmpty(SerackKeyInTitle) || EF.Functions.Like(c.Title, $"%{SerackKeyInTitle}%")).Paginate(pagination, p => p.ID).Select(p => new PosterPagedDto
            {
                Title = p.Title,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                WebSiteAddress = p.WebSiteAddress,
                Description = p.Description
            }).ToListAsync(cancellationToken);
        }
    }
}