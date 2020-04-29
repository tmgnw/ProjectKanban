using KanbanApi.Models;
using KanbanApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repository.Interface
{
    interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<IEnumerable<User>> Get(int id);

        Task<IEnumerable<User>> Login(UserVM userVM);

        Task<IEnumerable<UserVM>> Create(UserVM userVM);
    }
}
