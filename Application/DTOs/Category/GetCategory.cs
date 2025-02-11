using System.ComponentModel.DataAnnotations;


namespace ShopClothing.Application.DTOs.Category
{
    public class GetCategory : CategoryBase
    {
        [Required]
        public Guid CategoryID { get; set; }
        public int? CountNumberProductByCategory { get; set; } = 0;
      
    }
}
