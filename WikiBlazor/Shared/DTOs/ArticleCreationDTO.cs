using System.ComponentModel.DataAnnotations;

namespace WikiBlazor.Shared.DTOs
{
    public class ArticleCreationDTO
    {
        [Required]
        public int NumberOfArticlesToCreate { get; set; }
    }
}