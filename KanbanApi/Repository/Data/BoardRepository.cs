using KanbanApi.Models;
using KanbanApi.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repository.Data
{
    public class BoardRepository : GeneralRepository<Board, myContext>
    {
        public BoardRepository(myContext myContexts) : base(myContexts)
        {
        }
    }
}
