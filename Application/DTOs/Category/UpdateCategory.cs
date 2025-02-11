using System.ComponentModel.DataAnnotations;


namespace ShopClothing.Application.DTOs.Category
{
    public class UpdateCategory : CategoryBase
    {
        [Required]
        public Guid CategoryID { get; set; }
    }
}
