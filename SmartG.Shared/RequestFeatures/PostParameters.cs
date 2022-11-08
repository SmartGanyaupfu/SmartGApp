using System;
namespace SmartG.Shared.RequestFeatures
{
    public class PostParameters:RequestParameters
    {
        public PostParameters()
        {
        }

        public string Author { get; set; }
        public string Category { get; set; }
    }
}

