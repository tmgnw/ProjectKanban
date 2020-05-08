using KanbanApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.ViewModels
{
    public class ProjectVM
    {
        public int Id { get; set; }
        public string Manager_Id { get; set; }

        public string Manager { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

    }
}
