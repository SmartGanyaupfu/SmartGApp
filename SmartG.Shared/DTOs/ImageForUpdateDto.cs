﻿using System;
namespace SmartG.Shared.DTOs
{
    public class ImageForUpdateDto
    {
        public ImageForUpdateDto()
        {
        }

        public int ImageId { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? PublicId { get; set; }
        public string? AltText { get; set; }
        public string? Caption { get; set; }

    }
}

