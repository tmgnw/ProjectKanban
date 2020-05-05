using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KanbanApi.Models;
using KanbanApi.MyContext;
using KanbanApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KanbanClient.Controllers
{
    public class BoardController : Controller
    {
        //private myContext db = new myContext();

        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44320/api/")
        };

        public IActionResult Index()
        {
            return View(LoadBoard());
        }

        public JsonResult LoadBoard()
        {
            BoardJson boardVM = null;
            var responseTask = client.GetAsync("Board");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                boardVM = JsonConvert.DeserializeObject<BoardJson>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "server error, try after some time");
            }
            return Json(boardVM);
        }

        //public JsonResult AddBoard(BoardVM board)
        //{
        //    var myContent = JsonConvert.SerializeObject(board);
        //    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
        //    var byteContent = new ByteArrayContent(buffer);
        //    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    var result = client.PostAsync("Auth/register", byteContent).Result;
        //    return Json(result);
        //}

        //public ActionResult Create([Bind(Include = "Name")] BoardVM board)
        //{
        //    board.User_Id = System.Web.HttpContext.Current.User.Identity.GetUserId();

        //    if (ModelState.IsValid)
        //    {
        //        db.Boards.Add(board);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(board);
        //}

    }
}