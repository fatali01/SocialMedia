using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Data.Entities;

namespace SocialMedia.Data
{
    public class AppDbContext : IdentityDbContext<Users, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

            DbSet<Users> Users { get; set; } = null!;
            DbSet<Replies> Replies { get; set; } = null!;
            DbSet<Posts> Posts { get; set; } = null!;
            DbSet<Comments> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Replies>().ToTable("Replies");
            modelBuilder.Entity<Posts>().ToTable("Posts");
            modelBuilder.Entity<Comments>().ToTable("Comments");
        }
    }
}