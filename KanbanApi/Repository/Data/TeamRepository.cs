using KanbanApi.Context;
using KanbanApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repository.Data
{
    public class TeamRepository : GeneralRepository<Team, MyContext>
    {
        public TeamRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
