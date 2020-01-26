using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebWorkShop.Models
{
    public class WebWorkShopContext : DbContext
    {
        public WebWorkShopContext (DbContextOptions<WebWorkShopContext> options)
            : base(options)
        {
        }

        public DbSet<WebWorkShop.Models.Department> Department { get; set; }
    }
}
