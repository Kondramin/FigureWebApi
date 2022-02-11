using AutoMapper;
using Figure.Data.Entity.Entities.Base;
using Figure.Interfaces.Base.Entities;
using Figure.Interfaces.Base.Repositories;
using Figure.Interfaces.MathOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FigureWebApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class DtoController<T, TBase> : ControllerBase
        where T : IMappedEntity, new()
        where TBase : IEntity, new()
    {
        private readonly IRepository<TBase> _Repository;
        private readonly IMapper _Mapper;
        private readonly IMathOperation _MathOperation;

        public DtoController(IRepository<TBase> repository, IMapper mapper, IMathOperation mathOperation)
        {
            _Repository = repository;
            _Mapper = mapper;
            _MathOperation = mathOperation;
        }


        protected virtual T GetT(TBase item) => _Mapper.Map<T>(item);
        protected virtual IEnumerable<T> GetT(IEnumerable<TBase> items) => _Mapper.Map<IEnumerable<T>>(items);

        protected virtual TBase GetBase(T item) => _Mapper.Map<TBase>(item);
        protected virtual IEnumerable<TBase> GetBase(IEnumerable<T> items) => _Mapper.Map<IEnumerable<TBase>>(items);


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNew(T item)
        {
            if (item is null) return BadRequest();
            item = GetT(await _Repository.AddAsync(GetBase(item)));

            return Ok(item);
        }


        [HttpGet("id/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(double))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(int))]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0) return BadRequest();
            var item = await _Repository.GetAsync(id);
            if (item is null) return NotFound(id);

            if (item is not FigureEntity figureEntity) return BadRequest();
            
            var result = _MathOperation.CalculateArea(figureEntity);

            return Ok(result);
        }
    }
}
