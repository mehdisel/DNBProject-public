using DNBProject.Entities.DataTransferObjects;
using DNBProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNBProject.UI.Models
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItemsViewModel> CartItems { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
