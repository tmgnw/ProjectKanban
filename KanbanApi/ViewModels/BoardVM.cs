using KanbanApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.ViewModels
{
    public class BoardVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Team_Id { get; set; }
    }
}
