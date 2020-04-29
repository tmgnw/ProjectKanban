using KanbanApi.Models;
using KanbanApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KanbanApi.Repository.Data
{
    public class BoardRepository : GeneralRepository<Board, MyContext>
    {
        public BoardRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
