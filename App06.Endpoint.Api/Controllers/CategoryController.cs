using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App01.Domain.Entities;
using App02.Contract.Contracts.Common;
using App03.AppService.Communication;
using App05.Bootstraper.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using App03.Infrastructure.DB.DTOs;
using App05.Bootstraper.Resources.Categories;
using Microsoft.Extensions.Options;

namespace App06.Endpoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IBaseRepository<Category> _CategoryRepository;
        private readonly AutoMapperConfiguration _mapper;

        public CategoryController(IBaseRepository<Category> CategoryRepository, IOptions<AutoMapperConfiguration> mapperOption)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapperOption.Value;
        }

        [HttpGet]
        public async Task<ApiResponse<List<CategoryDTO>>> Get(CancellationToken cancellationToken)
        {
            List<CategoryDTO> Categoris = await _CategoryRepository.NoTrackEntities.ProjectTo<CategoryDTO>(_mapper.Mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return Ok(Categoris);
        }

        [HttpGet("{id:int}")]
        public async Task<ApiResponse<CategoryDTO>> Get(int id, CancellationToken cancellationToken)
        {
            Category requestedCategory = await _CategoryRepository.GetByIdAsync(id, cancellationToken);

            return Ok(_mapper.Mapper.Map<CategoryDTO>(requestedCategory));
        }

        [HttpPost]
        public ApiResponse<AddCategoryResource> Post(AddCategoryResource category, CancellationToken cancellationToken)
        {
            Category MapppedCategory = _mapper.Mapper.Map<Category>(category);
            _CategoryRepository.AddAsync(MapppedCategory, cancellationToken);
            return Ok(category);
        }
        [HttpPut]
        public ApiResponse<CategoryDTO> Put(CategoryDTO category, CancellationToken cancellationToken)
        {
            Category mappedCategory = _mapper.Mapper.Map<Category>(category);
            _CategoryRepository.UpdateAsync(mappedCategory, cancellationToken);
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public  ApiResponse<string> Delete(int id, CancellationToken cancellationToken)
        {
             _CategoryRepository.DeleteAsync(new Category { ID = id }, cancellationToken);
            return Ok($"دسته بندی با آیدی {id} حذف گردید"); 
        }
    }
}