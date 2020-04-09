using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWorkShop.Models;

namespace WebWorkShop.Models.ViewModels
{
    public class SalesRecordsViewModel 
    {

        public Seller Seller { get; set; }
        public Department Departments { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; }

    }
}
