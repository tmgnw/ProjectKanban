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
        public string TaskList_Id { get; set; }
        public string TaskList { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
