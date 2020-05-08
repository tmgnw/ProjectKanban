using KanbanApi.Models;
using KanbanApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using KanbanApi.ViewModels;
using System.Data.SqlClient;
using System.Data;

namespace KanbanApi.Repository.Data
{
    public class ProjectRepository : GeneralRepository<Project, MyContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }
        private readonly MyContext _myContext;
        public ProjectRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<ProjectVM>> GetAllProject(string Id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                parameters.Add("@Id", Id);
                var procName = "SP_Retrieve_TB_M_Project";
                var data = await connection.QueryAsync<ProjectVM>(procName,parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        // REPO GET BY ID WITH DAPPER
        public async Task<IEnumerable<ProjectVM>> GetByIdProject(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_GetById_TB_M_Project";
                parameters.Add("@Id", id);
                var data = await connection.QueryAsync<ProjectVM>(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        } 

        public int Insert(ProjectVM projectVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Insert_TB_M_Project";
                parameters.Add("@Name", projectVM.Name);
                parameters.Add("@Description", projectVM.Description);
                parameters.Add("@Manager_Id", projectVM.Manager_Id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Update(int id, ProjectVM projectVM)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Update_TB_M_Project";
                parameters.Add("@Id", id);
                parameters.Add("@Name", projectVM.Name);
                parameters.Add("@Description", projectVM.Description);
                parameters.Add("@Manager_Id", projectVM.Manager_Id);
                var data = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public int Remove(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
            {
                var procName = "SP_Delete_TB_M_Project";
                parameters.Add("@Id", id);
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
