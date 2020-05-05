using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.ViewModels
{
    public class CardVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? FinishDate { get; set; }
        public int Position { get; set; }
        public int StatusList_Id { get; set; }
    }
}
