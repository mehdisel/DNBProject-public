using DNBProject.Entities.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.Entities.Entity
{
    public class PaymentType : IEntity
    {
        public int ID { get; set; }
        public string PaymentName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}