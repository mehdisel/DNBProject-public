using DNBProject.DAL.DatabaseContext;
using DNBProject.DAL.EF.Interfaces;
using DNBProject.DAL.EF.Repository;
using DNBProject.Entities.DataTransferObjects;
using DNBProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DNBProject.DAL.EF.DalClasses
{
    public class ShoppingCartDal : EFEntityRepositoryBase<ShoppingCart, DNBProjectContext>, IShoppingCartDal
    {
        public void AddOrUpdate(CartItem shoppingCartItem)
        {
            using (var context = new DNBProjectContext())
            {
                var result = from CartItem in context.CartItems
                             join ShoppingCart in context.ShoppingCarts
                             on CartItem.IDShoppingCart equals ShoppingCart.ID
                             join product in context.Products
                             on CartItem.IDProduct equals product.ID
                             where CartItem.IDShoppingCart == shoppingCartItem.IDShoppingCart && ShoppingCart.IsClosed==false
                             select new ShoppingCartItemsViewModel
                             {
                                 ProductID = product.ID,
                                 ProductName = product.ProductName,
                                 Price = product.Price,
                                 Quantity = CartItem.Quantity,
                                 ShoppingCartID = CartItem.IDShoppingCart
                             };
                if (result.Any(x => x.ProductID == shoppingCartItem.IDProduct))
                {
                    CartItem item = context.CartItems.Where(x => x.IDProduct == shoppingCartItem.IDProduct && x.IDShoppingCart == shoppingCartItem.IDShoppingCart).FirstOrDefault();
                    item.Quantity += shoppingCartItem.Quantity;
                    context.SaveChanges();
                }
                else
                {
                    context.CartItems.Add(shoppingCartItem);
                    context.SaveChanges();

                }

            }
        }

        public List<ShoppingCartItemsViewModel> GetShoppingCartItems(ShoppingCart shoppingCart)
        {
            using (var context = new DNBProjectContext())
            {
                var result = from CartItem in context.CartItems
                             join ShoppingCart in context.ShoppingCarts
                             on CartItem.IDShoppingCart equals ShoppingCart.ID
                             join product in context.Products
                             on CartItem.IDProduct equals product.ID
                             where CartItem.IDShoppingCart == shoppingCart.ID
                             select new ShoppingCartItemsViewModel
                             {
                                 ProductID = product.ID,
                                 ProductName = product.ProductName,
                                 Price = product.Price,
                                 Quantity = CartItem.Quantity,
                                 ShoppingCartID = CartItem.IDShoppingCart
                             };

                return result.ToList();
            }
        }

        public void RemoveItem(CartItem shoppingCartItem)
        {
            using (var context = new DNBProjectContext())
            {
                context.CartItems.Remove(shoppingCartItem);
                context.SaveChanges();
            }

        }
    }
}
