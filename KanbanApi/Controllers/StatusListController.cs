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
    public class StatusListController : BasesController<StatusList, StatusListRepository>
    {
        private readonly StatusListRepository _repository;

        public StatusListController(StatusListRepository repository) : base(repository)
        {
            this._repository = repository;

        }

        // API PUT STATUS LIST

        [HttpPut("{id}")]
        public async Task<ActionResult<StatusList>> Put(int id, StatusList entity)
        {
            var update = await _repository.Get(id);

            if (update == null)
            {
                return BadRequest();
            }

            if (entity.Name != null)
            {
                update.Name = entity.Name;
            }

            if (entity.Board_Id != null)
            {
                update.Board_Id = entity.Board_Id;
            }

            update.UpdateDate = DateTimeOffset.Now;
            await _repository.Put(update);
            return Ok("Update Successfully");
        }
    }
}