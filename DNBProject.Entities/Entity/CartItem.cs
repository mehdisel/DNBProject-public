

using DNBProject.Entities.Types;

namespace DNBProject.Entities.Entity
{
    public class CartItem:IEntity
    {

        public int IDShoppingCart { get; set; }

        public int IDProduct { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}