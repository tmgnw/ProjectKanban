using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanApi.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanbanApi.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public BasesController(TRepository repository)
        {
            this._repository = repository;
        }

        // API GET 
        [HttpGet]
        public async Task<ActionResult<TEntity>> Get()
        {
            var get = await _repository.Get();
            return Ok(new { data = get });
        }

        // API GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> Get(int id)
        {
            var get = await _repository.Get(id);
            if (get == null)
            {
                return NotFound();
            }
            return Ok(get);
        }

        // API POST
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await _repository.Post(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // API PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<TEntity>> Put(int id, TEntity entity)
        {
            entity.Id = id;
            await _repository.Put(entity);
            return Ok("Update Succesfull");
        }

        // API DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var delete = await _repository.Delete(id);
            if (delete == null)
            {
                return NotFound();
            }
            return delete;
        }
    }
}