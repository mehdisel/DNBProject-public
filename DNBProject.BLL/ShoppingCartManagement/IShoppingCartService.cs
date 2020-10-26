using DNBProject.Entities.DataTransferObjects;
using DNBProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.BLL.ShoppingCartManagement
{
   public interface IShoppingCartService
    {
        ShoppingCart GetShoppingCartByUserID(int IDUser);
        List<ShoppingCartItemsViewModel> GetShoppingCartItems(ShoppingCart shoppingCart);
        void AddOrUpdate(CartItem shoppingCartItem);
        void RevomeItem(CartItem shoppingCartItem);
        void CloseShoppingCart(ShoppingCart closedCart);

    }
}
