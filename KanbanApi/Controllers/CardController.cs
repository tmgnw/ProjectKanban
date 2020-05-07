using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanApi.Base;
using KanbanApi.Models;
using KanbanApi.Repository.Data;
using KanbanApi.ViewModels;
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

        // API GET ALL WITH DAPPER
        [HttpGet]
        [Route("GetAll/{Id}")]
        public async Task<IEnumerable<CardVM>> GetAll(string Id)
        {
            return await _repository.GetAllCard(Id);
        }

        // API POST WITH DAPPER
        [HttpPost("Insert")]
        public IActionResult Insert(CardVM cardVM)
        {
            _repository.Insert(cardVM);
            return Ok("Insert Succesfully");
        }

        [HttpGet]
        [Route("ChartInfo")]
        public async Task<IEnumerable<ChartVM>> Chart()
        {
            return await _repository.GetChart();
        }

        /*    [HttpGet("{id}")]
            public async Task<IEnumerable<CardVM>> GetById(int id)
            {
                return await _repository.GetByIdCard(id);
            }
            */

        /*     [HttpPut("{id}")]
             public IActionResult Put(int id, CardVM cardVM)
             {
                 _repository.Update(id, cardVM);
                 return Ok("Updated Succesfully");
             }

             [HttpDelete("{id}")]
             public IActionResult Delete(int id)
             {
                 _repository.Remove(id);
                 return Ok("Deleted Succesfully");
             }

         */

    }
}