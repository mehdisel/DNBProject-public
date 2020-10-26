using DNBProject.DAL.EF.Repository;
using DNBProject.Entities.DataTransferObjects;
using DNBProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.DAL.EF.Interfaces
{
    public interface IShoppingCartDal:IRepository<ShoppingCart>
    {
        List<ShoppingCartItemsViewModel> GetShoppingCartItems(ShoppingCart shoppingCart);
        void AddOrUpdate(CartItem shoppingCart);
        void RemoveItem(CartItem shoppingCartItem);
    }
}
