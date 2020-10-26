using DNBProject.Entities.Types;
using System;
using System.Collections.Generic;

namespace DNBProject.Entities.Entity
{
    public class ShoppingCart : IEntity
    {
        public int ID { get; set; }

        public bool IsClosed { get; set; }

        public DateTime ProcessDate { get; set; }

        public int UserID { get; set; }

        public DateTime? ClosingDate { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual Order Order { get; set; }

        public virtual User User { get; set; }
    }
}