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
    public class BoardRepository : GeneralRepository<Board, MyContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }
        public BoardRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
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


    }
}
