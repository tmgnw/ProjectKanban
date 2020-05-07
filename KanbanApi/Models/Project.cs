using KanbanApi.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KanbanApi.Models
{
    [Table("TB_M_Project")]
    public class Project : IEntity
    {
        public Project()
        {
            this.TaskLists = new List<TaskList>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("Manager")]
        public int Manager_Id { get; set; }
        public virtual User Manager { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public virtual ICollection<TaskList> TaskLists { get; set; }


    }

    public class ProjectJson
    {
        [JsonProperty("data")]
        public IList<Project> data { get; set; }
    }
}
