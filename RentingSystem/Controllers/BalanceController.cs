using Microsoft.AspNetCore.Mvc;
using RentingSystem.Core.Contracts;
using RentingSystem.Core.Models.Balance;
using System.Security.Claims;
using static RentingSystem.Infrastructure.Constants.ToastrMessageConstants;
namespace RentingSystem.Controllers
{
    public class BalanceController : BaseController
    {
        private readonly IBalanceService balanceService;

        public BalanceController(IBalanceService _balanceService)
        {
            balanceService = _balanceService;
        }

        public async Task<IActionResult> Manage()
        {
            var userId = User.Id();
            var balance = await balanceService.GetBalanceAsync(userId);
            var model = new BalanceViewModel
            {
                Balance = balance
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> TopUp(decimal amount)
        {
            if (amount <= 0)
            {
                TempData[Error] = BalanceGreateThanZero;
                return RedirectToAction(nameof(Manage));
            }

            var userId = User.Id();
            await balanceService.AddBalanceAsync(userId, amount);
            TempData[Success] = BalanceSuccess;
            return RedirectToAction(nameof(Manage));
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                TempData[Error] = BalanceGreateThanZero;
                return RedirectToAction(nameof(Manage));
            }

            var userId = User.Id();
            var success = await balanceService.DeductBalanceAsync(userId, amount);

            if (!success)
            {
                TempData[Error] = BalanceNotEnough;
                return RedirectToAction(nameof(Manage));

            }
            TempData[Success] = SuccesWithdraw;
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public async Task<IActionResult> History()
        {
            string userId = User.Id();

            var transactions = await balanceService.GetUserTransactionsAsync(userId);
            return View(transactions);
        }
    }
}
