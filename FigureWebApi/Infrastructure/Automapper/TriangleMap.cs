using AutoMapper;
using Figure.Data.Entity.Entities;
using FigureWebApi.DtoModels;

namespace FigureWebApi.Infrastructure.Automapper
{
    public class TriangleMap : Profile
    {
        public TriangleMap()
        {
            CreateMap<Triangle, TriangleDto>().ReverseMap();
        }
    }
}
