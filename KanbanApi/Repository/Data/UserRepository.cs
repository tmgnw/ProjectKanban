using Dapper;
using KanbanApi.Context;
using KanbanApi.Models;
using KanbanApi.Repository.Interface;
using KanbanApi.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repository.Data
{
    public class UserRepository : GeneralRepository<User, MyContext>
    {

        public UserRepository(MyContext myContext) : base(myContext)
        {

        }
    
  /*      DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }
        private readonly MyContext _myContext;
        public UserRepository(MyContext myContext, IConfiguration configuration) 
        {
            this._configuration = configuration;
            this._myContext = myContext;
        }

        public async Task<IEnumerable<UserVM>> Create(UserVM userVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                parameters.Add("@FullName", userVM.FullName);
                parameters.Add("@Email", userVM.Email);
                parameters.Add("@Password", userVM.Password);
                var result = await connection.QueryAsync<UserVM>("SP_InsertDataUsers", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public int Delete(int Id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                parameters.Add("@Id", Id);
                var result = connection.Execute("SP_InsertDataUsers", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<User>> Get()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_GetAll_User";
                var data = await connection.QueryAsync<User>(procName, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public async Task<IEnumerable<User>> Get(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                parameters.Add("@Id", id);
                var result = await connection.QueryAsync<User>("SP_GetbyIdUsers", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<User>> Login(UserVM userVM)
        {
            var data = (IEnumerable<User>)null;

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
                {
                    parameters.Add("@Email", userVM.Email);
                    parameters.Add("@Password", userVM.Password);
                    data = await connection.QueryAsync<User>("SP_Login",parameters, commandType: CommandType.StoredProcedure);
                    return data;
                }
            }
            catch (Exception) { }
            
            return data;

        }

        public int Update(int Id, UserVM userVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                parameters.Add("@Id", Id);
                parameters.Add("@FullName", userVM.FullName);
                parameters.Add("@Password", userVM.Password);
                var result = connection.Execute("SP_UpdateDataUsers", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public User GetByEmail(string email)
        {
            return _myContext.Users.Where(s => s.Email == email).FirstOrDefault();
        }
        */
    }
}
