﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.ViewModels
{
    public class TaskListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Project_Id { get; set; }

        public string Project { get; set; }

        public string Status { get; set; }
    }
}
