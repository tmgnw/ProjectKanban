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
    public class UserBoardController : ControllerBase
    {
     private readonly UserBoardRepository _repository;

        public UserBoardController(UserBoardRepository repository) 
        {
            this._repository = repository;

        }

        [HttpGet]
        public async Task<IEnumerable<ProjectManagerVM>> GetAll()
        {
            return await _repository.GetAllUserBoard();
        }

       
        [HttpPost]
        public IActionResult Insert(ProjectManagerVM userBoardVM)
        {
            _repository.Insert(userBoardVM);
            return Ok("Insert Succesfully");
        }

   
    }
}