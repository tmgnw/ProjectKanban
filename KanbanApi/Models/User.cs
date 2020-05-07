using KanbanApi.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Models
{
    [Table("TB_M_User")]
    public class User : IEntity
    {
        public User()
        {
            this.Projects = new List<Project>();
        }

        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }

    public class UserJson
    {
        [JsonProperty("data")]
        public IList<User> data { get; set; }
    }
}
