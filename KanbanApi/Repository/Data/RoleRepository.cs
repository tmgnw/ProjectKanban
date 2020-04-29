using Dapper;
using KanbanApi.Context;
using KanbanApi.Models;
using KanbanApi.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repository.Data
{
    public class RoleRepository : GeneralRepository<Role, MyContext>
    {

        public RoleRepository(MyContext myContext) : base(myContext)
        {

        }
        /*
            DynamicParameters parameters = new DynamicParameters();
            IConfiguration _configuration { get; }
            private readonly MyContext _myContext;
            public RoleRepository(MyContext myContext, IConfiguration configuration)
            {
                this._configuration = configuration;
                this._myContext = myContext;
            }

            public async Task<IEnumerable<User>> Get()
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
                {
                    var procName = "SP_GetAll_Role";
                    var data = await connection.QueryAsync<User>(procName, commandType: CommandType.StoredProcedure);
                    return data;
                }
            }

            public async Task<IEnumerable<User>> Get(int id)
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("MyNetCoreConnection")))
                {
                    parameters.Add("@Id", id);
                    var result = await connection.QueryAsync<User>("SP_GetbyIdRole", parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            */
    }
}
