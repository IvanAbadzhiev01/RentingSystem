namespace RentingSystem.Infrastructure.Constants
{
    public static class DataConstants
    {
        //EngineType
        public const int EngineTypeNameMinLength = 3;    
        
        public const int EngineTypeNameMaxLength = 50;

        //Cars
        public const int CarMakeMinLength = 2;

        public const int CarMakeMaxLength = 50;

        public const int CarModelMinLength = 2;

        public const int CarModelMaxLength = 50;

        public const int CarDescriptionMinLength = 50;

        public const int CarDescriptionMaxLength = 5000;

        public const int CarTitleMinLength = 5;

        public const int CarTitleMaxLength = 50;

        public const int CarShiftMinLength = 3;

        public const int CarShiftMaxLength = 30;

        public const int CarFuelTypeMinLength = 3;

        public const int CarFuelTypeMaxLength = 50;

        public const string CarPriceMinValue = "0";

        public const string CarPriceMaxValue = "100000";

        public  const int CarSeatsMinValue = 1;

        public  const int CarSeatsMaxValue = 100;

        public const int CarYearMinValue = 1900;

        public const int CarYearMaxValue = 2030;


        //Dealer
        public const int DealerPhoneMaxLength = 15;

        public const int DealerPhoneMinLength = 7;

        //ApplicationUser
        public const int ApplicationUserFirstNameMinLength = 2;
        public const int ApplicationUserFirstNameMaxLength = 50;
        public const int ApplicationUserLastNameMinLength = 2;
        public const int ApplicationUserLastNameMaxLength = 50;

        //Review
        public const int ReviewScoreMaxValue = 5;
        public const int ReviewScoreMinValue = 1;
        public const int ReviewCommentMaxLength = 500;
        public const int ReviewCommentMinLength = 10;
    }
}
