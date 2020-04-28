using KanbanApi.Models;
using KanbanApi.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repository.Data
{
    public class CardRepository : GeneralRepository<Card, myContext>
    {
        public CardRepository(myContext myContexts) : base(myContexts)
        {
        }
    }
}
