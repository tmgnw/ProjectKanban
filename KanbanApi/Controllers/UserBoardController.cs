using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanApi.Repository.Data;
using KanbanApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanbanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBoardController : ControllerBase
    {
        private readonly UserBoardRepository _repository;

        public UserBoardController(UserBoardRepository repository)
        {
            this._repository = repository;

        }

        [HttpGet]
        public async Task<IEnumerable<UserBoardVM>> GetAll()
        {
            return await _repository.GetAllUserBoard();
        }


        [HttpGet("{id}")]
        public async Task<IEnumerable<UserBoardVM>> GetById(int id)
        {
            return await _repository.GetByIdUserBoard(id);
        }


        [HttpPost]
        public IActionResult Insert(int User_Id, int Board_Id)
        {
            _repository.Insert(User_Id, Board_Id);
            return Ok("Insert Succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserBoardVM userBoardVM)
        {
            _repository.Update(id, userBoardVM);
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