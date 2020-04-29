using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Models
{
    [Table("TB_T_Board_Card")]
    public class BoardCard 
    {
        [ForeignKey("Board")]
        public int Board_Id { get; set; }
        public Board Board { get; set; }

        [ForeignKey("Card")]
        public int Card_Id { get; set; }
        public Card Card { get; set; }
    }
}
