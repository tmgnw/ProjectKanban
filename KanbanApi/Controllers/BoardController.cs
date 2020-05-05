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
    public class BoardController : ControllerBase
    {
        private readonly BoardRepository _repository;

        public BoardController(BoardRepository repository) 
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<BoardVM>> GetAll()
        {
            return await _repository.GetAllBoard();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<BoardVM>> GetById(int id)
        {
            return await _repository.GetByIdBoard(id);
        }

        [HttpPost]
        public IActionResult Insert(BoardVM boardVM)
        {
            _repository.Insert(boardVM);
            return Ok("Insert Succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, BoardVM boardVM)
        {
            _repository.Update(id, boardVM);
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