using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KanbanClient.Controllers
{
    public class BoardController : Controller
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

        //[HttpGet]
        //public IActionResult All()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public async Task <IActionResult> Open(int id)
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(Board board)
        //{
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(Board boardUpdate)
        //{
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return View();
        //}

        //public IActionResult Error()
        //{
        //    return View();
        //}

    }
}