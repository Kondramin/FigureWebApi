using Figure.Interfaces.Base.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FigureWebApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class MappedEntityController<T, TBase>
        where T : IEntity, new()
        where TBase : IMappedEntity, new()
    {
        //TODO: Realize controller
    }
}
