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
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<StatusList> StatusLists { get; set; }

        [ForeignKey("Team")]
        public int Team_Id { get; set; }
        public Team Team { get; set; }

    }
}
