using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KanbanApi.Models;
using KanbanApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KanbanClient.Controllers
{
    public class TaskListController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44320/api/")
        };
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult LoadTaskList()
        {
            //var client = new HttpClient
            //{
            //    BaseAddress = new Uri("https://localhost:44320/api/")
            //};
            int hehe = 12;
            string Id = hehe.ToString(); ; //HttpContext.Session.GetString("Id");
        //    client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));

            IEnumerable<TaskListVM> tasklist = null;
            var responseTask = client.GetAsync("TaskList/GetAll/" + Id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<TaskListVM>>();
                readTask.Wait();
                tasklist = readTask.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(tasklist);
        }

        public JsonResult LoadTaskList2()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44320/api/")
            };
           client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));

            TaskListJson tasklist = null;
            var responseTask = client.GetAsync("TaskList/");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                tasklist = JsonConvert.DeserializeObject<TaskListJson>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(tasklist);
        }


        public JsonResult InsertOrUpdate(TaskListVM tasklistVM)
        {
            //var client = new HttpClient
            //{
            //    BaseAddress = new Uri("https://localhost:44320/api/")
            //};
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));
            //tasklistVM.Project_Id = HttpContext.Session.GetString("Id");
            var myContent = JsonConvert.SerializeObject(tasklistVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (tasklistVM.Id.Equals(0))
            {
                var result = client.PostAsync("TaskList/Insert", byteContent).Result;
                return Json(result);
            }
            else
            {
                var result = client.PutAsync("TaskList/" + tasklistVM.Id, byteContent).Result;
                return Json(result);
            }
        }

        public JsonResult GetById(int Id)
        {
            //var client = new HttpClient
            //{
            //    BaseAddress = new Uri("https://localhost:44320/api/")
            //};
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));

            TaskList tasklist = null;
            var responseTask = client.GetAsync("TaskList/" + Id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                tasklist = JsonConvert.DeserializeObject<TaskList>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "server error, try after some time");
            }
            return Json(tasklist);
        }

        public JsonResult Delete(int Id)
        {
            //var client = new HttpClient
            //{
            //    BaseAddress = new Uri("https://localhost:44320/api/")
            //};
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));

            var result = client.DeleteAsync("TaskList/" + Id).Result;
            return Json(result);
        }
    }
}