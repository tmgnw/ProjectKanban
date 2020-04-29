using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanApi.Base;
using KanbanApi.Models;
using KanbanApi.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanbanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : BasesController<Board, BoardRepository>
    {
        private readonly BoardRepository _repository;

        public BoardController(BoardRepository repository) : base(repository)
        {
            this._repository = repository;
        }

        // API PUT BOARD
        [HttpPut("{id}")]
        public async Task<ActionResult<Board>> Put(int id, Board entity)
        {
            entity.Id = id;
            if (id != entity.Id)
            {
                return BadRequest();
            }
            var put = await _repository.Get(id);
            put.Name = entity.Name;
            put.UpdateDate = DateTimeOffset.Now;
            await _repository.Put(put);
            return Ok("Update Successfully");
        }
    }
}