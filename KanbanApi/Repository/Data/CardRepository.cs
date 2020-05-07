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
    public class CardRepository : GeneralRepository<Card, MyContext>
    {
       DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }
        private readonly MyContext _myContext;
        public CardRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<CardVM>> GetAllCard(string Id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                parameters.Add("@Id", Id);
                var procName = "SP_Retrieve_TB_T_Card";
                var data = await connection.QueryAsync<CardVM>(procName, parameters,commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public async Task<IEnumerable<CardVM>> GetByIdCard(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_GetById_TB_T_Card";
                parameters.Add("@Id", id);
                var data = await connection.QueryAsync<CardVM>(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Insert(CardVM cardVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Insert_TB_T_Card";
                parameters.Add("@Name", cardVM.Name);
                parameters.Add("@Description", cardVM.Description);
                parameters.Add("@Status", cardVM.Status);
                parameters.Add("@TaskList_Id", cardVM.TaskList_Id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Update(int id, CardVM cardVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Update_TB_T_Card";
                parameters.Add("@Id", id);
                parameters.Add("@Name", cardVM.Name);
                parameters.Add("@Description", cardVM.Description);
                parameters.Add("@Status", cardVM.Status);
                parameters.Add("@TaskList_Id", cardVM.TaskList_Id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Remove(int Id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Delete_TB_T_Card";
                parameters.Add("@Id", Id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public async Task<IEnumerable<ChartVM>> GetChart()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var spName = "SP_GetChart";
                var data = await connection.QueryAsync<ChartVM>(spName, commandType: CommandType.StoredProcedure);
                return data;
            }
        }
    }
}
