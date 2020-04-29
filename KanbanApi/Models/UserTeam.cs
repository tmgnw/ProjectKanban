using Microsoft.EntityFrameworkCore;
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
        [ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; }

        [ForeignKey("Team")]
        public int Team_Id { get; set; }
        public Team Team { get; set; }

    }
}
