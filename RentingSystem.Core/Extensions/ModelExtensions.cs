using RentingSystem.Core.Contracts;
using System.Text.RegularExpressions;

namespace RentingSystem.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this ICarModel car)
        {
            string info = car.Make.Replace(" ", "-") + car.Model.Replace(" ", "-") + car.Year;

            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

       
    }
}
