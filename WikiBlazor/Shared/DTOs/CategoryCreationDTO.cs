using System.ComponentModel.DataAnnotations;

namespace WikiBlazor.Shared.DTOs
{
    public class CategoryCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}