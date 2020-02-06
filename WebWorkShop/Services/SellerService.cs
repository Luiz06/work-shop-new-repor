using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWorkShop.Models;

namespace WebWorkShop.Services
{
    public class SellerService
    {
        private readonly WebWorkShopContext _context;

        public SellerService(WebWorkShopContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
