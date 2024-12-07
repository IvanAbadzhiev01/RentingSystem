namespace RentingSystem.Infrastructure.Constants
{
    public static class ToastrMessageConstants
    {
        public const string Success = "Success";

        public const string Error = "Error";

        //Car
        public const string CarReturnSuccess = "Car returned successfully";

        public const string CarRentSuccess = "Car rented successfully";

        public const string CarRentError = "Car rent failed";

        public const string CarReturnError = "Car return failed";

        public const string AddedCarSuccess = "Car added successfully wait for approve you car!";

        public const string EditCarSuccess = "Car edited successfully!";

        public const string DeleteCarSuccess = "Car deleted successfully!";

        //Balance
        public const string BalanceGreateThanZero = "Balance must be greater than zero!";

        public const string BalanceSuccess = "Balance added successfully!";

        public const string BalanceNotEnough = "Insufficient funds!";

        public const string SuccesWithdraw = "Withdrawal successful!";

    }
}
