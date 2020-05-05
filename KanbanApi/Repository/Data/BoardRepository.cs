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
    public class BoardRepository : GeneralRepository<Board, myContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }

        private readonly myContext _myContext;
        public BoardRepository(myContext myContexts, IConfiguration configuration) : base(myContexts)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<BoardVM>> GetAllBoard()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Retrieve_TB_M_Board";
                var data = await connection.QueryAsync<BoardVM>(procName, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public async Task<IEnumerable<BoardVM>> GetByIdBoard(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_GetById_TB_M_Team";
                parameters.Add("@Id", id);
                var data = await connection.QueryAsync<BoardVM>(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Insert(BoardVM boardVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Insert_TB_M_Board";
                parameters.Add("@Name", boardVM.Name);
                parameters.Add("@Team_Id", boardVM.User_Id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Update(int id, BoardVM boardVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Update_TB_M_Board";
                parameters.Add("@Id", id);
                parameters.Add("@Name", boardVM.Name);
                parameters.Add("@Team_Id", boardVM.User_Id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Remove(int Id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Delete_TB_M_Board";
                parameters.Add("@Id", Id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }
    }
}
