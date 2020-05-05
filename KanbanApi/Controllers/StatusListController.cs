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
    public class StatusListController : ControllerBase
    {
        private readonly StatusListRepository _repository;

        public StatusListController(StatusListRepository repository) 
        {
            this._repository = repository;

        }

        [HttpGet]
        public async Task<IEnumerable<StatusListVM>> GetAll()
        {
            return await _repository.GetAllStatusList();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<StatusListVM>> GetById(int id)
        {
            return await _repository.GetByIdStatusList(id);
        }

        [HttpPost]
        public IActionResult Insert(StatusListVM statusListVM)
        {
            _repository.Insert(statusListVM);
            return Ok("Insert Succesfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, StatusListVM statusListVM)
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