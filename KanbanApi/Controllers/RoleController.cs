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
    public class RoleController : BasesController<Role, RoleRepository>
    {
        private readonly RoleRepository _repository;

        public RoleController(RoleRepository repository) : base(repository)
        {
            this._repository = repository;

        }
    }
}