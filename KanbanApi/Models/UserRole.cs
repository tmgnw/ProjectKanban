using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Models
{
    [Table("TB_T_User_Role")]
    public class UserRole
    {
        [ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; }

        [ForeignKey("Role")]
        public int Role_Id { get; set; }
        public Role Role { get; set; }
    }
}
