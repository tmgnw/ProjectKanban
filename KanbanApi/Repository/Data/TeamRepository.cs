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
    public class TeamRepository : GeneralRepository<Team, MyContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }
        private readonly MyContext _myContext;
        public TeamRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<TeamVM>> GetAllTeam()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Retrieve_TB_M_Team";
                var data = await connection.QueryAsync<TeamVM>(procName, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public async Task<IEnumerable<TeamVM>> GetByIdTeam(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_GetById_TB_M_Team";
                parameters.Add("@Id", id);
                var data = await connection.QueryAsync<TeamVM>(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Insert(TeamVM teamVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Insert_TB_M_Team";
                parameters.Add("@Name", teamVM.Name);
                parameters.Add("@Description", teamVM.Description);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Update(int id, TeamVM teamVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Update_TB_M_Team";
                parameters.Add("@Id", id);
                parameters.Add("@Name", teamVM.Name);
                parameters.Add("@Description", teamVM.Description);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Remove(int Id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Delete_TB_M_Team";
                parameters.Add("@Id", Id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }

        }
    }
}
