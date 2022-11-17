using System;
namespace SmartG.Shared.RequestFeatures
{
    public class PostParameters:RequestParameters
    {
        public PostParameters()
        {
        }

        public string Author { get; set; }
        public int SgCategoryId { get; set; }
    }
}

