namespace RentingSystem.Core.Models.Rent
{
    public class RentHistoryViewModel
    {
        public int CarId { get; set; }
        public int RentId { get; set; }
        public string CarTitle { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsReviewed { get; set; } 
        public bool IsReturned { get; set; }
        
    }
}
