using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KanbanApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KanbanClient.Controllers
{
    public class UserController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44320/api/")
        };
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult LoadUser()
        {
            UserJson user = null;
            var responseTask = client.GetAsync("User/");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                user = JsonConvert.DeserializeObject<UserJson>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(user);
        }



    }
}