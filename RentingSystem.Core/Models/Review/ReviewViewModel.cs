using System.ComponentModel.DataAnnotations;
using static RentingSystem.Infrastructure.Constants.DataConstants;
using static RentingSystem.Infrastructure.Constants.ErrorConstants;
namespace RentingSystem.Core.Models.Review
{
    public class ReviewViewModel
    {
        public int CarId { get; set; }

        [Required(ErrorMessage = ReqiredFildError)]
        [Range(ReviewScoreMinValue, ReviewScoreMaxValue, ErrorMessage = RangeError)]
        public int Rating { get; set; }

        [Required(ErrorMessage = ReqiredFildError)]
        [StringLength(ReviewCommentMaxLength)]
        public string Comment { get; set; } = null!;
    }
}
