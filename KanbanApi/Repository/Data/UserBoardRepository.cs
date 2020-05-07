using Dapper;
using KanbanApi.Context;
using KanbanApi.Models;
using KanbanApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repository.Data
{
    public class UserBoardRepository  
    {

       DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }
        private readonly MyContext _myContext;
        public UserBoardRepository(MyContext myContext, IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<ProjectManagerVM>> GetAllUserBoard()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Retrieve_TB_T_User_Board";
                var data = await connection.QueryAsync<ProjectManagerVM>(procName, commandType: CommandType.StoredProcedure);
                return data;
            }
        }
        public int Insert(ProjectManagerVM userBoardVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Insert_TB_T_User_Board";
                parameters.Add("@User_Id", userBoardVM.User_Id);
                parameters.Add("@Board_Id", userBoardVM.Board_Id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        /*     public async Task<IEnumerable<UserBoardVM>> GetByIdUserBoard(int id)
             {
                 using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
                 {
                     var procName = "SP_GetById_TB_M_User_Board";
                     parameters.Add("@Id", id);
                     var data = await connection.QueryAsync<UserBoardVM>(procName, parameters, commandType: CommandType.StoredProcedure);
                     return data;
                 }
             }

             public int Insert(UserBoardVM userBoardVM)
             {
                 using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
                 {
                     var procName = "SP_Insert_TB_M_User_Board";
                     parameters.Add("@UserId", userBoardVM.User_Id);
                     parameters.Add("@BoardId", userBoardVM.Board_Id);
                     var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                     return data;
                 }
             }

             public int Update(UserBoardVM userBoardVM)
             {
                 using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
                 {
                     var procName = "SP_Update_TB_M_Team";
                     parameters.Add("@Id", userBoardVM);
                     parameters.Add("@Name", teamVM.Name);
                     parameters.Add("@Description", teamVM.Description);
                     var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                     return data;
                 }
             }

             public int Remove(int Id)

                 using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
                 {
                     var procName = "SP_Delete_TB_M_User_Board";
                     parameters.Add("@Id", Id);
                     var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                     return data;
                 }
             }
             */

    }
}

