using DNBProject.Entities.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.Entities.Entity
{
    public class Product : IEntity
    {
        public int ID { get; set; }

        public string ProductName { get; set; }

        public int IDProductType { get; set; }

        public int InStock { get; set; }


        public decimal Price { get; set; }

        public bool IsDeleted { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
