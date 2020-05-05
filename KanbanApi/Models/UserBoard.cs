using KanbanApi.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Models
{
    [Table("TB_T_User_Board")]
    public class UserBoard : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Board")]
        public int Board_Id { get; set; }
        public virtual Board Board { get; set; }
    }
}
