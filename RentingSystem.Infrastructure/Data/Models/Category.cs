using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RentingSystem.Infrastructure.Constants.DataConstants;
namespace RentingSystem.Infrastructure.Data.Models
{
    [Comment("Category of the car")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(EngineTypeNameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = string.Empty;
        [Comment("List of cars")]
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
