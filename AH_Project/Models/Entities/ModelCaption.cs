using System.ComponentModel.DataAnnotations;

namespace AH_Project.Models.Entities
{
    public class ModelCaption
    {
        public int Id { get; set; }
        public int Image_Id { get; set; }
        public int Model_Id { get; set; }
        [Required]
        public string? Caption { get; set; }



    }
}
