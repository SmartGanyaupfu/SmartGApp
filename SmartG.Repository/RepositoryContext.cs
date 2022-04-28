using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartG.Entities.Models;
using SmartG.Repository.Configuration;

namespace SmartG.Repository
{
    //add project ref -> contracts and and entities
    public class RepositoryContext : IdentityDbContext<User>
    {
        //Remember to install MS.Entityframworkcore
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*optional relationships*/
            modelBuilder.Entity<Post>()
            .HasOne(p => p.Category)
            .WithMany(p=>p.Posts)
            .IsRequired(false);

          modelBuilder.Entity<Portifolio>()
             .HasOne(p => p.Category)
             .WithMany(b => b.Portifolios)
             .IsRequired(false);



            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PageConfiguration());

        }
        public DbSet<Page>? Pages { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Portifolio> Portifolios { get; set; }
        public DbSet<Category>? Categories { get; set; }
        /*  public DbSet<Image> Images { get; set; }*/
        public DbSet<Comment>? Comments { get; set; }
        //public DbSet<Image>? Images { get; set; }
    }
}

