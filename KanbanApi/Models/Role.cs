using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Models
{
    [Table("TB_M_Role")]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
