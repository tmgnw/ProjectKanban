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
    public class CardRepository : GeneralRepository<Card, myContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }

        private readonly myContext _myContext;
        public CardRepository(myContext myContexts, IConfiguration configuration) : base(myContexts)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<CardVM>> GetAllCard()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Retrieve_TB_T_Card";
                var data = await connection.QueryAsync<CardVM>(procName, commandType: CommandType.StoredProcedure);
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
                parameters.Add("@StartDate", cardVM.StartDate);
                parameters.Add("@FinishDate", cardVM.FinishDate);
                parameters.Add("@Position", cardVM.Position);
                parameters.Add("@StatusList_Id", cardVM.StatusList_Id);
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
                parameters.Add("@StartDate", cardVM.StartDate);
                parameters.Add("@FinishDate", cardVM.FinishDate);
                parameters.Add("@Position", cardVM.Position);
                parameters.Add("@StatusList_Id", cardVM.StatusList_Id);
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
    }
}
