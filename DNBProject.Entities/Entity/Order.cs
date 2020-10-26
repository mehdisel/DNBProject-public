using DNBProject.Entities.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.Entities.Entity
{
    public class Order: IEntity
    {
        public int ID { get; set; }

        public string TotalPrice { get; set; }

        public int IDPaymentType { get; set; }

        public DateTime PaymentDate { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}