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
    public class StatusListRepository : GeneralRepository<StatusList, myContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }

        private readonly myContext _myContext;
        public StatusListRepository(myContext myContexts, IConfiguration configuration) : base(myContexts)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<StatusListVM>> GetAllStatusList()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Retrieve_TB_T_Status_List";
                var data = await connection.QueryAsync<StatusListVM>(procName, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public async Task<IEnumerable<StatusListVM>> GetByIdStatusList(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_GetById_TB_T_Status_List";
                parameters.Add("@Id", id);
                var data = await connection.QueryAsync<StatusListVM>(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Insert(StatusListVM statusListVM)
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

        public int Update(int id, StatusListVM statusListVM)
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

        public int Remove(int Id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Delete_TB_T_Status_List";
                parameters.Add("@Id", Id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }
    }
}
