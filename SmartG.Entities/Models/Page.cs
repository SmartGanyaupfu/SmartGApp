﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace SmartG.Entities.Models
{
    public class Page:BaseEntity
    {
        public int PageId { get; set; }
        
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }

        public int? SgImageId { get; set; }
        public int? SgGalleryId { get; set; }
        public ICollection<ContentBlock>? ContentBlocks { get; set; }
       
        


    }
}

