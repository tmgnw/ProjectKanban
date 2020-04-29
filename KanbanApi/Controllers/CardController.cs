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
    public class CardController : BasesController<Card, CardRepository>
    {
        private readonly CardRepository _repository;

        public CardController(CardRepository repository) : base(repository)
        {
            this._repository = repository;

        }
    }
}