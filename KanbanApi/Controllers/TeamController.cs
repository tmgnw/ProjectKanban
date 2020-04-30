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
    public class TeamController : ControllerBase
    {
        private readonly TeamRepository _repository;

        public TeamController(TeamRepository repository) 
        {
            this._repository = repository;

        }

        [HttpGet]
        public async Task<IEnumerable<TeamVM>> GetAll()
        {
            return await _repository.GetAllTeam();
        }

        
        [HttpGet("{id}")]
        public async Task<IEnumerable<TeamVM>> GetById(int id)
        {
            return await _repository.GetByIdTeam(id);
        }

    
        [HttpPost]
        public IActionResult Insert(TeamVM teamVM)
        {
            _repository.Insert(teamVM);
            return Ok("Insert Succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TeamVM teamVM)
        {
            _repository.Update(id, teamVM);
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