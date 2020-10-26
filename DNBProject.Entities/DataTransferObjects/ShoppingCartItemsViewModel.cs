using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.Entities.DataTransferObjects
{
    public class ShoppingCartItemsViewModel
    {
        public int ProductID { get; set; }
        public int ShoppingCartID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal TotalPrice { get => Price * Quantity; }
    }
}
