using Dapper;
using KanbanApi.Models;
using KanbanApi.MyContext;
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
    public class UserRepository : GeneralRepository<User, myContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }

        private readonly myContext _myContext;

        public UserRepository(myContext myContext, IConfiguration configuration) : base(myContext)
        {
            this._configuration = configuration;
            this._myContext = myContext;
        }

        public async Task<IEnumerable<UserVM>> GetAllUser()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Retrieve_TB_M_User";
                var data = await connection.QueryAsync<UserVM>(procName, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public async Task<IEnumerable<UserVM>> GetByIdUser(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_GetById_TB_M_User";
                parameters.Add("@Id", id);
                var result = await connection.QueryAsync<UserVM>(procName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public int Insert(UserVM userVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Insert_TB_M_User";
                parameters.Add("@FullName", userVM.FullName);
                parameters.Add("@Email", userVM.Email);
                parameters.Add("@Password", userVM.Password);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Update(int id, UserVM userVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Update_TB_M_User";
                parameters.Add("@Id", id);
                parameters.Add("@FullName", userVM.FullName);
                parameters.Add("@Email", userVM.Email);
                parameters.Add("@Password", userVM.Password);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Remove(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Delete_TB_M_User";
                parameters.Add("@Id", id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }
    }
}
