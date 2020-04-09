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

            return await _context.SalesRecord.Include(obj => obj.Seller).OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<List<SalesRecord>> FindAByDateAsync(DateTime? minDate, DateTime? maxDate)
        {

            var result = from obj in _context.SalesRecord select obj;
            if(minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result.Include(x => x.Seller).Include(x => x.Seller.Department).OrderByDescending(x => x.Date).
                ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindAByDateGroupAsync(DateTime? minDate, DateTime? maxDate)
        {

            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result.Include(x => x.Seller).
                Include(x => x.Seller.Department).
                OrderByDescending(x => x.Date).
                GroupBy(x => x.Seller.Department).
                ToListAsync();
        }
    }
}
