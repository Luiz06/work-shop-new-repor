﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWorkShop.Models.ViewModels
{
    public class SellerViewModel 
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }



    }
}
