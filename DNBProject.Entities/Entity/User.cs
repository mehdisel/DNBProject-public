using DNBProject.Entities.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.Entities.Entity
{
    public class User : IEntity
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
