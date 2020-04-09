using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebWorkShop.Models.ViewModels;
using WebWorkShop.Services;

namespace WebWorkShop.Controllers
{
    public class SalesRecordsController : Controller
    {

        private readonly SalesRecordsService _salesRecordsService;
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SalesRecordsController( SalesRecordsService salesRecordsService, DepartmentService departmentService, SellerService sellerService)
        {
            _sellerService = sellerService;
            _salesRecordsService = salesRecordsService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {

            var list = await _salesRecordsService.FindAllAsync();
            return View(list);


        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if(!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if(!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordsService.FindAByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupSearch(DateTime? minDate, DateTime? maxDate)
        {


            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordsService.FindAByDateGroupAsync(minDate, maxDate);
            return View(result);
        }
    }
}