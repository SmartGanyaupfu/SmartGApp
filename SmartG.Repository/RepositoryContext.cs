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

            ///optional relationships
            modelBuilder.Entity<Post>()
            .HasOne(p => p.Category)
            .WithMany(p=>p.Posts)
            .IsRequired(false);

          modelBuilder.Entity<Portfolio>()
             .HasOne(p => p.Category)
             .WithMany(b => b.Portfolios)
             .IsRequired(false);

           /* modelBuilder.Entity<Post>()
                .HasOne(i => i.Image)
                .WithOne(p => p.Post)
                .IsRequired(false);
            modelBuilder.Entity<Post>()
             .HasMany(c => c.Comments)
             .WithOne(p => p.Post)
             .IsRequired(false);

            modelBuilder.Entity<Page>()
              .HasOne(i => i.Image)
              .WithOne(p => p.Page)
              .IsRequired(false);
            modelBuilder.Entity<Portfolio>()
              .HasOne(i => i.Image)
              .WithOne(p => p.Portfolio)
              .IsRequired(false);

            modelBuilder.Entity<Portfolio>()
                .HasMany(c => c.Comments)
                .WithOne(p => p.Portfolio)
                .IsRequired(false);*/





            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PageConfiguration());

        }
        public DbSet<Page>? Pages { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<ContentBlock>? ContentBlocks { get; set; }
        public DbSet<OfferedService> Services { get; set; }
        public DbSet<Widget> Widgets { get; set; }
    }
}

