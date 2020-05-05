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
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? FinishDate { get; set; }
        public int Position { get; set; }

        [Required]
        [ForeignKey("StatusList")]
        public int StatusList_Id { get; set; }
        public virtual StatusList StatusList { get; set; }
    }
}
