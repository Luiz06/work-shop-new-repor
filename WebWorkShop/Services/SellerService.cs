using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWorkShop.Models;
using Microsoft.EntityFrameworkCore;
using WebWorkShop.Services.Excepitons;
using WebWorkShop.Services.Exceptions;

namespace WebWorkShop.Services
{
    public class SellerService
    {
        private readonly WebWorkShopContext _context;

        public SellerService(WebWorkShopContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();

            }catch(DbUpdateException )
            {
                throw new IntegrityException("Não posso deletar o vendedor pois há vendas");
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasSync = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!hasSync)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
