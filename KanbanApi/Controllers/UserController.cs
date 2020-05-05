using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanApi.Repository.Data;
using KanbanApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KanbanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UserController(UserRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserVM>> GetAll()
        {
            return await _repository.GetAllUser();
        }


        [HttpGet("{id}")]
        public async Task<IEnumerable<UserVM>> GetById(int id)
        {
            return await _repository.GetByIdUser(id);
        }


        [HttpPost]
        public IActionResult Insert(UserVM userVM)
        {
            _repository.Insert(userVM);
            return Ok("Insert Succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserVM userVM)
        {
            _repository.Update(id, userVM);
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