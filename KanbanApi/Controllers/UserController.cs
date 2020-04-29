using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using KanbanApi.Base;
using KanbanApi.Context;
using KanbanApi.Models;
using KanbanApi.Repository.Data;
using KanbanApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KanbanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BasesController<User, UserRepository>
    {
        private readonly UserRepository _repository;

        public UserController(UserRepository repository) : base(repository)
        {
            this._repository = repository;






            /*  private readonly UserRepository _userRepository;
              private readonly RoleRepository _roleRepository;
              public IConfiguration _configuration;

              public UserController(IConfiguration configuration, UserRepository userRepository, RoleRepository roleRepository)
              {
                  this._configuration = configuration;
                  this._roleRepository = roleRepository;
                  this._userRepository = userRepository;
              }

              // API POST Create User
              [HttpPost]
              [Route("Register")]
              public async Task<IActionResult> Register(UserVM userVM)
              {
                  var check = _userRepository.GetByEmail(userVM.Email);
                  if (check != null)
                  {
                      return BadRequest("Email Already Used!");
                  }

                  else
                  {
                      var post = await _userRepository.Create(userVM);
                      if (post != null)
                      {
                          return Ok("Register Succesfull!");
                      }
                  }
                  return BadRequest("Failed to Register");
              }
              */
        }
    }
}