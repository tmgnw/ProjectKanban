using KanbanApi.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Models
{
    [Table("TB_M_Board")]
    public class Board : IEntity
    {
        public Board()
        {
            this.StatusLists = new HashSet<StatusList>();
            this.UserBoards = new HashSet<UserBoard>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StatusList> StatusLists { get; set; }
        public virtual ICollection<UserBoard> UserBoards { get; set; }

        [Required]
        [ForeignKey("User")]
        public int User_Id { get; set; }
        public virtual User User { get; set; }
    }
}
