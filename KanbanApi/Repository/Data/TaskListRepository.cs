using KanbanApi.Models;
using KanbanApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using KanbanApi.ViewModels;
using System.Data.SqlClient;
using System.Data;

namespace KanbanApi.Repository.Data
{
    public class TaskListRepository : GeneralRepository<Models.TaskList, MyContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }
        private readonly MyContext _myContext;
        public TaskListRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<TaskListVM>> GetAllStatusList()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Retrieve_TB_T_Status_List";
                var data = await connection.QueryAsync<TaskListVM>(procName, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public async Task<IEnumerable<TaskListVM>> GetByIdStatusList(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_GetById_TB_T_Status_List";
                parameters.Add("@Id", id);
                var data = await connection.QueryAsync<TaskListVM>(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Insert(TaskListVM statusListVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Insert_TB_T_Status_List";
                parameters.Add("@Name", statusListVM.Name);
                parameters.Add("@Board_Id", statusListVM.Board_Id);
                parameters.Add("@Position", statusListVM.Position);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Update(int id, TaskListVM statusListVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Update_TB_T_Status_List";
                parameters.Add("@Id", id);
                parameters.Add("@Name", statusListVM.Name);
                parameters.Add("@Board_Id", statusListVM.Board_Id);
                parameters.Add("@Position", statusListVM.Position);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Remove(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Delete_TB_T_Status_List";
                parameters.Add("@Id", id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }
    }
}
