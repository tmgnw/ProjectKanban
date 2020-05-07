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
    public class CardController : Controller
    {
        //readonly HttpClient client = new HttpClient
        //{
        //    BaseAddress = new Uri("https://localhost:44320/api/")
        //};
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult LoadCard()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44320/api/")
            };
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));

            IEnumerable<CardVM> card = null;
            var responseTask = client.GetAsync("Card/GetAll/");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<CardVM>>();
                readTask.Wait();
                card = readTask.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(card);
        }

        public JsonResult InsertOrUpdate(CardVM cardVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44320/api/")
            };
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));
            //cardVM.TaskList_Id = HttpContext.Session.GetString("Id");
            var myContent = JsonConvert.SerializeObject(cardVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (cardVM.Id.Equals(0))
            {
                var result = client.PostAsync("Card/Insert", byteContent).Result;
                return Json(result);
            }
            else
            {
                var result = client.PutAsync("Card/" + cardVM.Id, byteContent).Result;
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

            Card card = null;
            var responseTask = client.GetAsync("Card/" + Id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                card = JsonConvert.DeserializeObject<Card>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "server error, try after some time");
            }
            return Json(card);
        }

        public JsonResult Delete(int Id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44320/api/")
            };
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString(("JWToken")));

            var result = client.DeleteAsync("Card/" + Id).Result;
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
            var responseTask = client.GetAsync("Card/ChartInfo"); //Access data from employees API
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