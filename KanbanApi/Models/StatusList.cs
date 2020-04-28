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
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Board")]
        public int Board_Id { get; set; }
        public Board Board { get; set; }
        public virtual ICollection<Card> Cards { get; set; }

        public bool IsDelete { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public Nullable<DateTimeOffset> UpdateDate { get; set; }
        public Nullable<DateTimeOffset> DeleteDate { get; set; }
    }
}
