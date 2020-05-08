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
    public class ProjectController : Controller
    {
        /*  readonly HttpClient client = new HttpClient
           {
               BaseAddress = new Uri("https://localhost:44320/api/")
           };
           */

        [HttpGet]
        public IActionResult Index()
        {
            var id = HttpContext.Session.GetString("Id");
            if (id != null)
            {
                return View();
            }
            return RedirectToAction("Login","Auth");
        }

        public JsonResult LoadProject()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44320/api/")
            };
            string Id = HttpContext.Session.GetString("Id");
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));

            IEnumerable<ProjectVM> project = null;
            var responseTask = client.GetAsync("Project/GetAll/"+Id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ProjectVM>>();
                readTask.Wait();
                project = readTask.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(project);
        }

        public JsonResult LoadProject2()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44320/api/")
            };
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));

            ProjectJson project = null;
            var responseTask = client.GetAsync("Project/");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                project = JsonConvert.DeserializeObject<ProjectJson>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(project);
        }
        

        public JsonResult InsertOrUpdate(ProjectVM projectVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44320/api/")
            };
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));
            projectVM.Manager_Id = HttpContext.Session.GetString("Id");
            
            var myContent = JsonConvert.SerializeObject(projectVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (projectVM.Id.Equals(0))
            {
                var result = client.PostAsync("Project/Insert", byteContent).Result;
                return Json(result);
            }
            else
            {
                var result = client.PutAsync("Project/" + projectVM.Id, byteContent).Result;
                return Json(result);
            }
        }

        public JsonResult GetById(int Id)
           {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44320/api/")
            };
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));

            Project project = null;
               var responseTask = client.GetAsync("Project/"+ Id);
               responseTask.Wait();
               var result = responseTask.Result;
               if (result.IsSuccessStatusCode)
               {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                project = JsonConvert.DeserializeObject<Project>(json);
               }
               else
               {
                ModelState.AddModelError(string.Empty, "server error, try after some time");
            }
               return Json(project);
           }

           public JsonResult Delete(int Id)
           {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44320/api/")
            };
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));

            var result = client.DeleteAsync("Project/"+Id).Result;
               return Json(result);
           }

        public JsonResult GetChart()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44320/api/")
            };
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));
            
            IEnumerable<ChartVM> chartInfo = null;
            List<ChartVM> chartData = new List<ChartVM>();
            var responseTask = client.GetAsync("Project/ChartInfo"); //Access data from employees API
            responseTask.Wait(); //Waits for the Task to complete execution.
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode) // if access success
            {
                var readTask = result.Content.ReadAsAsync<IList<ChartVM>>(); //Get all the data from the API
                readTask.Wait();
                chartInfo = readTask.Result;
                foreach (var item in chartInfo)
                {
                    ChartVM data = new ChartVM();
                    data.label = item.label;
                    data.value = item.value;
                    chartData.Add(data);
                }
                var json = JsonConvert.SerializeObject(chartData, Formatting.Indented);
                return Json(json);
            }
            return Json("internal server error");
        }


    }




}