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
    public class TaskListController : BasesController<TaskList, TaskListRepository>
    {
        private readonly TaskListRepository _repository;

        public TaskListController(TaskListRepository repository) : base(repository)
        {
            this._repository = repository;
        }

        // API GET ALL WITH DAPPER
        [HttpGet]
        [Route("GetAll/{Id}")]
        public async Task<IEnumerable<TaskListVM>> GetAll(string Id)
        {
            return await _repository.GetAllTaskList(Id);
        }

        // API POST WITH DAPPER
        [HttpPost("Insert")]
        public IActionResult Insert(TaskListVM taskListVM)
        {
            _repository.Insert(taskListVM);
            return Ok("Insert Succesfully");
        }

        [HttpGet]
        [Route("ChartInfo")]
        public async Task<IEnumerable<ChartVM>> Chart()
        {
            return await _repository.GetChart();
        }

        /*    [HttpGet("{id}")]
            public async Task<IEnumerable<TaskListVM>> GetById(int id)
            {
                return await _repository.GetByIdStatusList(id);
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

    */
    }
}