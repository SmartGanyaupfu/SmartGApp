﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartG.Entities.Models
{
    public class Portfolio:BaseEntity
    {
        public Guid PortfolioId { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }


        public int? SgCategoryId { get; set; }
        public int? SgImageId { get; set; }
        public int? SgGalleryId { get; set; }
        public ICollection<Comment>? Comments { get; set; }
      
        public ICollection<ContentBlock>? ContentBlocks { get; set; }
        
    }

}


