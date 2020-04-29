using KanbanApi.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Models
{
    [Table("TB_M_Team")]
    public class Team : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<UserTeam> UserTeams { get; set; }

        public virtual ICollection<Board> Boards { get; set; }
    }
}
