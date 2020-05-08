using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using KanbanApi.Base;
using KanbanApi.Context;
using KanbanApi.Migrations;
using KanbanApi.Models;
using KanbanApi.Repository.Data;
using KanbanApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using DevOne.Security.Cryptography.BCrypt;
using System.Security.Cryptography;

namespace KanbanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BasesController<User, UserRepository>
    {
        private readonly UserRepository _repository;
        public IConfiguration _configuration;
        DynamicParameters parameters = new DynamicParameters();
        public UserController(UserRepository repository, IConfiguration configuration) : base(repository)
        {
            this._repository = repository;
            this._configuration = configuration;
        }


        // API POST Register  User
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> Register(UserVM userVM)
        {
            var checkEmail = _repository.GetByEmail(userVM.Email);

            if (checkEmail != null)
            {
                return BadRequest("Email Already Used!");
            }
            else
            {
                User user = new User();
                user.FullName = userVM.FullName;
                user.Email = userVM.Email;
                user.Password = userVM.Password;

                /*    string salt = BCryptHelper.GenerateSalt(6);
                    var hashedPassword = BCryptHelper.HashPassword(userVM.Password, salt);
                    user.Password = hashedPassword; */

                var post = _repository.Insert(user);
                if (post != null)
                {
                    return Ok("Register Succesfull!");
                }
            }
            return BadRequest("Failed to Register");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Get(LoginVM loginVM)
        {
            var getUser = _repository.GetByEmail(loginVM.Email);

            if (getUser == null)
            {
                return BadRequest("Email Wrong!");

            }

            else
            {

                if (loginVM.Password != getUser.Password)
                {
                    return BadRequest("Wrong Password!"); ;
                }
                else
                {
                    //get data from user login
                   var data = await _repository.Put(getUser);

                        var claims = new[]
                { //Create claims details based on the user information
                         //new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                         //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        //new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                          new Claim("Id",data.Id.ToString()),
                        new Claim("FullName",data.FullName),
                        new Claim("Email", data.Email),
                    };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddDays(1),
                            signingCredentials: signIn);

                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }


                }
            }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok("Logged out");
        }

    }
    }
