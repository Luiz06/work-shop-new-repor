using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

           
            return View();
        }

        public async Task<IActionResult> SimpleSearch()
        {


            return View();
        }

        public async Task<IActionResult> GroupSearch()
        {

           
            return View();
        }
    }
}