using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Models
{
    [Table("TB_T_User_Team")]
    public class UserTeam
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; }

        [ForeignKey("Team")]
        public int Team_Id { get; set; }
        public Team Team { get; set; }

        [ForeignKey("Board")]
        public int Board_Id { get; set; }
        public Board Board { get; set; }

        [ForeignKey("Role")]
        public int Role_Id { get; set; }
        public Role Role { get; set; }
    }
}
