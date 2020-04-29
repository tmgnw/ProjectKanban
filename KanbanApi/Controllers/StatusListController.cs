using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanApi.Base;
using KanbanApi.Models;
using KanbanApi.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace KanbanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusListController : BasesController<StatusList, StatusListRepository>
    {
        private readonly StatusListRepository _repository;

        public StatusListController(StatusListRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
    }