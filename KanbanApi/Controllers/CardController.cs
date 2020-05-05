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
    public class CardController : ControllerBase
    {
        private readonly CardRepository _repository;

        public CardController(CardRepository repository) 
        {
            this._repository = repository;

        }

        [HttpGet]
        public async Task<IEnumerable<CardVM>> GetAll()
        {
            return await _repository.GetAllCard();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<CardVM>> GetById(int id)
        {
            return await _repository.GetByIdCard(id);
        }

        [HttpPost]
        public IActionResult Insert(CardVM cardVM)
        {
            _repository.Insert(cardVM);
            return Ok("Insert Succesfully");
        }

        [HttpPut("{id}")]
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
    }
}