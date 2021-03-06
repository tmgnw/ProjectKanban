﻿using KanbanApi.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Models
{
    [Table("TB_T_Card")]
    public class Card : IEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TaskList")]
        public int TaskList_Id { get; set; }
        public virtual TaskList TaskList { get; set; }

        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

    }
}
