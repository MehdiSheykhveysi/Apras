using App05.Bootstraper.Resources.Posters;
using App01.Domain.Entities;
using App03.Infrastructure.DB.DTOs;
using AutoMapper;
using App05.Bootstraper.Resources.Categories;

namespace App05.Bootstraper.Mapping
{
    public class CommonMapping : Profile
    {
        public CommonMapping()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<AddPosterResource, Poster>();
            CreateMap<AddCategoryResource, Category>();
        }
    }
}