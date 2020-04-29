using KanbanApi.Models;
using KanbanApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repository.Data
{
    public class CardRepository : GeneralRepository<Card, MyContext>
    {
        public CardRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
