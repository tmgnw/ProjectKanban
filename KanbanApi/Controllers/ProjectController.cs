using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanApi.Base;
using KanbanApi.Models;
using KanbanApi.Repository.Data;
using KanbanApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanbanApi.Controllers
{

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : BasesController<Project, ProjectRepository>
    {
        private readonly ProjectRepository _repository;

        public ProjectController(ProjectRepository repository) : base (repository)
        {
            this._repository = repository;
        }


        // API GET ALL WITH DAPPER
        [HttpGet]
        [Route("GetAll/{Id}")]
        public async Task<IEnumerable<ProjectVM>> GetAll(string Id)
        {
            return await _repository.GetAllProject(Id); 
        }

        // API POST WITH DAPPER
        [HttpPost("Insert")]
        public IActionResult Insert(ProjectVM projectVM)
        {
            _repository.Insert(projectVM);
            return Ok("Insert Succesfully");
        }

     /*   // API DELETE WITH DAPPER
        [HttpDelete("Remove/{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Remove(id);
            return Ok("Deleted Succesfully");
        }

        // API PUT WITH DAPPER
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, ProjectVM projectVM)
        {
            _repository.Update(id, projectVM);
            return Ok("Updated Succesfully");
        }
        */

    }
}