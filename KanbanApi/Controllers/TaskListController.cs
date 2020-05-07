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
    public class TaskListController : ControllerBase
    {
        private readonly TaskListRepository _repository;

        public TaskListController(TaskListRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskListVM>> GetAll()
        {
            return await _repository.GetAllStatusList();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<TaskListVM>> GetById(int id)
        {
            return await _repository.GetByIdStatusList(id);
        }

        [HttpPost]
        public IActionResult Insert(TaskListVM statusListVM)
        {
            _repository.Insert(statusListVM);
            return Ok("Insert Succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TaskListVM statusListVM)
        {
            _repository.Update(id, statusListVM);
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