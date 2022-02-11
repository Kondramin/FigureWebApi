using AutoMapper;
using Figure.Data.Entity.Entities;
using Figure.Interfaces.Base.Repositories;
using Figure.Interfaces.MathOperations;
using FigureWebApi.Controllers.Base;
using FigureWebApi.DtoModels;

namespace FigureWebApi.Controllers
{
    public class TriangleController : MappedEntityController<TriangleDto, Triangle>
    {
        public TriangleController(IRepository<Triangle> repository, IMapper mapper, IMathOperation mathOperation) : base(repository, mapper, mathOperation) { } 
    }
}
