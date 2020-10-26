using DNBProject.Entities.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.Entities.Entity
{
    public class OrderDetail: IEntity
    {
        public int ID { get; set; }

        public int IDOrder { get; set; }

        public int IDProduct { get; set; }

        public int Quantity { get; set; }

        public decimal PriceOnSaleDate { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}