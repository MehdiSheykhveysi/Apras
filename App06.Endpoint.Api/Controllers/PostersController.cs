using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App01.Domain.Entities;
using App02.Contract.Contracts.DTOs;
using App03.AppService.Communication;
using App03.Infrastructure.DB.Repositories;
using App05.Bootstraper.Mapping;
using App05.Bootstraper.Resources;
using App05.Bootstraper.Resources.Posters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Apras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostersController : ControllerBase
    {

        private readonly IPosterRepository _posterRepository;
        private readonly AutoMapperConfiguration mapper;

        public PostersController(IPosterRepository posterRepository, IOptions<AutoMapperConfiguration> mapperOption)
        {
            _posterRepository = posterRepository;
            mapper = mapperOption.Value;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<IPosterPagedDto>>> Get(PaginationInfo pagination, CancellationToken cancellationToken)
        {
            IEnumerable<IPosterPagedDto> posters = await _posterRepository.GetPagedPosteAsync(pagination.SerackKeyInTitle, pagination, cancellationToken);
            return Ok(posters);
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<Poster>> Get(int id, CancellationToken cancellationToken)
        {
            Poster requestedPoster = await _posterRepository.GetByIdAsync(id, cancellationToken);
            return Ok(requestedPoster);
        }

        // POST api/Posters
        [HttpPost]
        public ApiResponse<AddPosterResource> Post(AddPosterResource poster, CancellationToken cancellationToken)
        {
            Poster posterMapped = mapper.Mapper.Map<Poster>(poster);

            posterMapped.AppUserId = Guid.NewGuid();//temporary

            _posterRepository.AddAsync(posterMapped, cancellationToken);
            return Ok(poster);

        }

        // PUT api/Posters
        [HttpPut]
        public ApiResponse<Poster> Put(EditposterResource poster, CancellationToken cancellationToken)
        {
            Poster SelectedPoster = mapper.Mapper.Map<Poster>(poster);
            _posterRepository.UpdateAsync(SelectedPoster, cancellationToken);
            return Ok(SelectedPoster);
        }

        // DELETE api/Posters/5
        [HttpDelete("{ID:guid}")]
        public ApiResponse<string> Delete(Guid ID, CancellationToken cancellationToken)
        {
            _posterRepository.DeleteAsync(new Poster { ID = ID }, cancellationToken);
            return Ok($"آگهی کورد نظر با ID {ID} حذف شد");
        }
    }
}