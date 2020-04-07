using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWorkShop.Models;

namespace WebWorkShop.Services
{
    public class SalesRecordsService
    {
        private readonly WebWorkShopContext _context;
 

        public SalesRecordsService(WebWorkShopContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindAllAsync()
        {
            return await _context.SalesRecord.OrderBy(x => x.Id).ToListAsync();
        }

    }
}
