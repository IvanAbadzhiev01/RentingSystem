namespace RentingSystem.Core.Models.Review
{
    public class CarWithoutReviewViewModel
    {
        public int CarId { get; set; }
        
        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
