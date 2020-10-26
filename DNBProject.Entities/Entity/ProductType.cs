using DNBProject.Entities.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.Entities.Entity
{
    public class ProductType : IEntity
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}