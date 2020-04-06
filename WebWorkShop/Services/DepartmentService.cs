using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWorkShop.Models;

namespace WebWorkShop.Services
{
    public class DepartmentService
    {

        private readonly WebWorkShopContext _context;

        public DepartmentService (WebWorkShopContext context)
        {
            _context = context;
        }


        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();

        }
    }
}
