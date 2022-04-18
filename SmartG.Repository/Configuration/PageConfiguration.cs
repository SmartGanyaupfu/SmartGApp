using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartG.Entities.Models;

namespace SmartG.Repository.Configuration
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasData(
                new Page
                {
                    PageId = 1,
                    Title = "Home",
                    Slug = "home",
                    Content = "The innner part of the solar cookker is made of mirroes",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    Deleted = false,
                    MetaDescription = "The inner was the inner",
                    MetaKeyWords = "test,tets,done",


                },
                     new Page
                     {
                         PageId = 2,
                         Title = "About",
                         Slug = "about",
                         Content = "The innner part of the solar cookker is made of mirroes",
                         DateCreated = DateTime.Now,
                         DateUpdated = DateTime.Now,
                         Deleted = false,
                         MetaDescription = "The inner was the inner",
                         MetaKeyWords = "test,tets,done",


                     }
                     ,
                          new Page
                          {
                              PageId = 3,
                              Title = "Contact",
                              Slug = "contact",
                              Content = "The innner part of the solar cookker is made of mirroes",
                              DateCreated = DateTime.Now,
                              DateUpdated = DateTime.Now,
                              Deleted = false,
                              MetaDescription = "The inner was the inner",
                              MetaKeyWords = "test,tets,done",


                          }
                );
        }
    }
}

