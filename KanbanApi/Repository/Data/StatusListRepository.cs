using KanbanApi.Models;
using KanbanApi.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repository.Data
{
    public class StatusListRepository : GeneralRepository<StatusList, myContext>
    {
        public StatusListRepository(myContext myContexts) : base(myContexts)
        {
        }
    }
}
