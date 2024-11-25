using System.ComponentModel.DataAnnotations;
using static RentingSystem.Infrastructure.Constants.DataConstants;
using static RentingSystem.Infrastructure.Constants.ErrorConstants;
namespace RentingSystem.Core.Models.Review
{
    public class ReviewViewModel
    {

        public string UserFullName { get; set; } = null!;
        public int CarId { get; set; }

        [Required(ErrorMessage = ReqiredFildError)]
        [Range(ReviewScoreMinValue, ReviewScoreMaxValue, ErrorMessage = RangeError)]
        public int Rating { get; set; }

        [Required(ErrorMessage = ReqiredFildError)]
        [StringLength(ReviewCommentMaxLength, MinimumLength = ReviewCommentMinLength, ErrorMessage = StringLengthError)]
        public string Comment { get; set; } = null!;
    }
}
