using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using ThanosApp.API.Models;

namespace ThanosApp.API.Data {
    public class DataContext : DbContext {
        public DataContext (DbContextOptions<DataContext> options) : base (options) { }
        //Admin Config
        public DbSet<AdminMenu> AdminMenus { get; set; }

        //User Details
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Committee> Committees { get; set; }

        public DbSet <NavBar> NavBar { get; set; }

        protected override void OnModelCreating (ModelBuilder builder) {

            builder.Entity<AdminMenu>()
            .HasOne(p => p.Parent)
            .WithMany(s => s.SubAdminMenu)
            .HasForeignKey(f => f.ParentId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Message> ()
                .HasOne (u => u.Sender)
                .WithMany (m => m.MessagesSent)
                .OnDelete (DeleteBehavior.Restrict);

            builder.Entity<Message> ()
                .HasOne (u => u.Recipient)
                .WithMany (m => m.MessagesRecieved)
                .OnDelete (DeleteBehavior.Restrict);

            // builder.Entity<Member> ()
            //     .HasOne (u => u.User)
            //     .WithMany (m => m.Members)
            //     .OnDelete (DeleteBehavior.Restrict);

            // builder.Entity<Gender> ()
            //     .HasOne (g => g.Users)
            //     .WithOne(u => u.Gender)
            //     .HasForeignKey<User>(g => g.GenderId);       
        }
    }
}