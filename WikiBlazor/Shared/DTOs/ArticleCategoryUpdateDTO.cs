using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WikiBlazor.Shared.DTOs
{
    public class ArticleCategoryUpdateDTO
    {
        [Required]
        public long ArticleId { get; set; }
        [Required]
        public IEnumerable<long> CategoryIds { get; set; }
    }
}
