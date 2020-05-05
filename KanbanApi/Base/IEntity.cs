using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Base
{
    public interface IEntity
    {
        int Id { get; set; }
        //bool IsDelete { get; set; }
        //DateTimeOffset CreateDate { get; set; }
        //Nullable<DateTimeOffset> UpdateDate { get; set; }
        //Nullable<DateTimeOffset> DeleteDate { get; set; }
    }
}
