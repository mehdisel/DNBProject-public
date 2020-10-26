
using DNBProject.DAL.EF.Interfaces;
using DNBProject.Entities.Entity;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNBProject.UI.Models
{
    public class ProductListViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public PagedList<Product> PagedList { get; set; }


    }
}
