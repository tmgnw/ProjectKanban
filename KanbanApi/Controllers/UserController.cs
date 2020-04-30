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
    public class UserController : ControllerBase
    {

        private readonly RoleRepository _roleRepository;
        private readonly UserRepository _userRepository;
        public IConfiguration _configuration;

        public UserController(UserRepository userRepository, RoleRepository roleRepository, IConfiguration configuration)
        {
            this._roleRepository = roleRepository;
            this._userRepository = userRepository;
            this._configuration = configuration;
        }

  /*      // API POST Create User
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
                User user = new User();
                user.Email = userVM.Email;
                user.Password = userVM.Password;
                user.FullName = userVM.FullName;
                var post = await _userRepository.Post(user);
                if (post != null)
                {
                    await _roleRepository.InsertUserRoles(user.Id, userVM.RoleId);
                    return Ok("Register Succesfull!");
                }
            }
            return BadRequest("Failed to Register");
        }


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