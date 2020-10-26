using DNBProject.DAL.EF.Interfaces;
using DNBProject.Entities.DataTransferObjects;
using DNBProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.BLL.ShoppingCartManagement
{
    public class ShoppingCartManager : IShoppingCartService
    {
        private readonly IShoppingCartDal _shoppingCartDal;
        public ShoppingCartManager(IShoppingCartDal shoppingCartDal)
        {
            _shoppingCartDal = shoppingCartDal;
        }
        public ShoppingCart GetShoppingCartByUserID(int IDUser)
        {
            ShoppingCart shoppingCart = _shoppingCartDal.GetByCondition(x => x.IsClosed == false && x.UserID == IDUser);
            return shoppingCart == null ? new ShoppingCart() : shoppingCart;
        }
        public List<ShoppingCartItemsViewModel> GetShoppingCartItems(ShoppingCart shoppingCart)
        {
            return _shoppingCartDal.GetShoppingCartItems(shoppingCart);
        }
        public void AddOrUpdate(CartItem shoppingCartItem)
        {

            _shoppingCartDal.AddOrUpdate(shoppingCartItem);
           
        }

        public void RevomeItem(CartItem shoppingCartItem)
        {
            _shoppingCartDal.RemoveItem(shoppingCartItem);
        }

        public void CloseShoppingCart(ShoppingCart closedCart)
        {

            _shoppingCartDal.Update(closedCart);
        }
    }
}
