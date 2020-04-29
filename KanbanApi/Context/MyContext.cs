using KanbanApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<BoardCard> BoardCards { get; set; }

        public DbSet<StatusList> StatusList { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }

        public DbSet<Team> Teams { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Define composite key.
            builder.Entity<BoardCard>()
                .HasKey(bc => new { bc.Board_Id, bc.Card_Id});
            builder.Entity<UserRole>()
            .HasKey(ur => new { ur.User_Id, ur.Role_Id });
            builder.Entity<UserTeam>()
            .HasKey(ut => new { ut.User_Id, ut.Team_Id });
        }
    }
}
