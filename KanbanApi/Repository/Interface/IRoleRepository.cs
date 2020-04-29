using KanbanApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repository.Interface
{
    public interface IRoleRepository
    {
        IEnumerable<Role> Get();
        Role Get(int Id);
    }
}
