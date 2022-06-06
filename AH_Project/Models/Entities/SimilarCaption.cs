
using System.ComponentModel.DataAnnotations;

namespace AH_Project.Models.Entities
{  
    public class SimilarCaption
    {
        public int Id { get; set; }
        public int Image_Id { get; set; }
        [Required]
        public string? Caption { get; set; }
    }
}
