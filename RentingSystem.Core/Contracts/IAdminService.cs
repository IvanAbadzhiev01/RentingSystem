using RentingSystem.Core.Enumerations;
using RentingSystem.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingSystem.Core.Contracts
{
    public interface IAdminService
    {
        Task<CarQueryServiceModel> GetForReviewAsync(string? category = null,
            string? searchTerm = null,
            CarSorting sorting = CarSorting.Newest,
            int currentPage = 1,
            int carsPerPage = 1);
    }
}
