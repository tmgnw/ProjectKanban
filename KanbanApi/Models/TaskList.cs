using KanbanApi.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanApi.Models
{
    [Table("TB_T_Task_List")]
    public class TaskList : IEntity
    {
        public TaskList()
        {
            this.Cards = new List<Card>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("Project")]
        public int Project_Id { get; set; }
        public virtual Project Project { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

    }

    public class TaskListJson
    {
        [JsonProperty("data")]
        public IList<TaskList> data { get; set; }
    }
}
