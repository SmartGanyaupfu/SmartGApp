using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartG.Entities.Models;

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
           
                //optional relationships
                modelBuilder.Entity<Post>()
            .HasOne(p => p.Category)
            .WithMany(b => b.Posts)
            .IsRequired(false);
            /*     modelBuilder.Entity<Image>()
            .HasOne(p => p.Career)
            .WithMany(b => b.Images)
            .IsRequired(false);
                modelBuilder.Entity<Image>()
            .HasOne(p => p.Qualification)
            .WithMany(b => b.Images)
            .IsRequired(false);

                //modelBuilder.Entity<Qualification>().ToTable("Metadata");*/

            /* modelBuilder.ApplyConfiguration(new ValueConfiguration());
             modelBuilder.ApplyConfiguration(new VoteConfiguration());
             modelBuilder.ApplyConfiguration(new NominationConfiguration());
             modelBuilder.ApplyConfiguration(new RoleConfiguration());
             modelBuilder.ApplyConfiguration(new VotingInProgressConfiguration());*/

        }
        public DbSet<Page>? Pages { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<Image>? Images { get; set; }
    }
}

