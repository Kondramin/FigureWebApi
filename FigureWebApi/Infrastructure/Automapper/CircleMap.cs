using AutoMapper;
using Figure.Data.Entity.Entities;
using FigureWebApi.DtoModels;

namespace FigureWebApi.Infrastructure.Automapper
{
    public class CircleMap : Profile
    {
        public CircleMap()
        {
            CreateMap<Circle, CircleDto>().ReverseMap();
        }
    }
}
