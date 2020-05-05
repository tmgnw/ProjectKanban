using KanbanApi.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Models
{
    [Table("TB_T_Status_List")]
    public class StatusList : IEntity
    {
        public StatusList()
        {
            this.Cards = new HashSet<Card>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public int Position { get; set; }

        [Required]
        [ForeignKey("Board")]
        public int Board_Id { get; set; }
        public virtual Board Board { get; set; }
    }
}
