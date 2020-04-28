using KanbanApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.MyContext
{
    public class myContext : DbContext
    {
        public myContext(DbContextOptions<myContext> options) : base(options) { }

        public DbSet<Board> Board { get; set; }
        public DbSet<StatusList> StatusList { get; set; }
        public DbSet<Card> Card { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Team> Team { get; set; }

        public DbSet<UserTeam> UserTeam { get; set; }
    }
}
