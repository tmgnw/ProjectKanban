using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KanbanClient.Controllers
{
    public class StatusListController : Controller
    {
        //private myContext _myContext;

        //public BoardController(myContext myContexts)
        //{
        //    _myContext = myContexts;
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}