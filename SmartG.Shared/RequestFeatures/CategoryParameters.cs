﻿using System;
namespace SmartG.Shared.RequestFeatures
{
    public class CategoryParameters:RequestParameters
    {
        public CategoryParameters()
        {
        }
        public string? SearchTerm { get; set; }
    }
}

