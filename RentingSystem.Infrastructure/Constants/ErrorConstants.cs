namespace RentingSystem.Infrastructure.Constants
{
    public static class ErrorConstants
    {
        public const string ReqiredFildError = "The {0} field is required.";
        public const string StringLengthError = "The {0} must be between {2} and {1} characters long.";
        public const string RangeError = "The {0} must be between {1} and {2}.";
        //Dealer
        public const string PhoneNumberExist = "Phone number already exists";
        public const string HasRents = "Dealer has rents";
        //Categoryes
        public const string CategoryNotExist = "Category does not exist";
    }
}