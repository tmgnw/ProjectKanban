using KanbanApi.Base;
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
            this.Boards = new HashSet<Board>();
            this.UserBoards = new HashSet<UserBoard>();
        }

        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<UserBoard> UserBoards { get; set; }
    }
}
