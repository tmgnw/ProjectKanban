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

        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<StatusList> StatusLists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBoard> UserBoards { get; set; }

        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserTeam> UserRoles { get; set; }
        //public DbSet<UserTeam> UserTeams { get; set; }
        //public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Define composite key.
            builder.Entity<UserBoard>()
            .HasKey(ub => new { ub.User_Id, ub.Board_Id });

            builder.Entity<Board>()
            .HasMany(e => e.UserBoards)
            .WithOne(e => e.Board).IsRequired()
            .HasForeignKey(e => e.Board_Id)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
            .HasMany(e => e.UserBoards)
            .WithOne(e => e.User).IsRequired()
            .HasForeignKey(e => e.User_Id)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
