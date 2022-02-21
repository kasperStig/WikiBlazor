using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WikiBlazor.Shared.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";

        [JsonIgnore]
        public List<Article> Articles { get; set; }
    }
}
