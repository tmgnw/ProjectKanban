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
    public class BoardController : BasesController<Board, BoardRepository>
    {
        private readonly BoardRepository _repository;

        public BoardController(BoardRepository repository) : base(repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IEnumerable<BoardVM>> GetAll()
        {
            return await _repository.GetAllBoard();
        }



    }
}