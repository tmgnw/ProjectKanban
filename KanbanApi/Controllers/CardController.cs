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
    public class CardController : BasesController<Card, CardRepository>
    {
        private readonly CardRepository _repository;

        public CardController(CardRepository repository) : base(repository)
        {
            this._repository = repository;

        }


        // API PUT CARD

        [HttpPut("{id}")]
        public async Task<ActionResult<Card>> Put(int id, Card entity)
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

            if (entity.Description != null)
            {
                update.Description = entity.Description;
            }

            if (entity.StartDate != default(DateTime))
            {
                update.StartDate = entity.StartDate;
            }

            if (entity.FinishDate != default(DateTime))
            {
                update.FinishDate = entity.FinishDate;
            }

            if (entity.StatusList_Id != null)
            {
                update.StatusList_Id = entity.StatusList_Id;
            }

            update.UpdateDate = DateTimeOffset.Now;
            await _repository.Put(update);
            return Ok("Update Successfully");
        }
    }
}