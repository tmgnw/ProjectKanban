using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KanbanApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KanbanClient.Controllers
{
    public class AuthController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44320/api/")
        };

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserVM userVM)
        {
            var myContent = JsonConvert.SerializeObject(userVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = client.PostAsync("User/Register", byteContent).Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM loginVM)
        {
            var myContent = JsonConvert.SerializeObject(loginVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PostAsync("User/Login", byteContent).Result;

            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsStringAsync().Result;
                var handler = new JwtSecurityTokenHandler();
                var tokens = handler.ReadJwtToken(data);

                var token = "Bearer " + data;
                string id = tokens.Claims.First(claim => claim.Type == "Id").Value;
                string email = tokens.Claims.First(claim => claim.Type == "Email").Value;

                HttpContext.Session.SetString("JWToken", token);
                HttpContext.Session.SetString("Id", id);
                HttpContext.Session.SetString("Email", email);

                if (token != null)
                {
                    return RedirectToAction("Index", "Project");
                }

                else
                {
                    return View(result);
                }
            }

            return BadRequest();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44320/api/")
            };
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWToken"));
            var result = client.GetAsync("User/Logout").Result;
            if (result.IsSuccessStatusCode)
            {
                HttpContext.Session.Remove("JWToken");
                HttpContext.Session.Remove("Id");
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

    }
}
