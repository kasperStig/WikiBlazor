using System.Collections.Generic;

namespace WikiBlazor.Shared.Models
{
    public class Article
    {
        public long Id { get; set; }
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
