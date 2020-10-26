using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNBProject.BLL.ShoppingCartManagement;
using DNBProject.Entities.Entity;
using DNBProject.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DNBProject.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ILogger<ShoppingCartController> _logger;
        public ShoppingCartController(IShoppingCartService shoppingCartService, ILogger<ShoppingCartController> logger)
        {
            _shoppingCartService = shoppingCartService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("userID")))
            {
                return RedirectToAction("Login", "User");
            }
            ShoppingCartViewModel shoppingCartController = new ShoppingCartViewModel()
            {
                CartItems = _shoppingCartService.GetShoppingCartItems(_shoppingCartService.GetShoppingCartByUserID(int.Parse(HttpContext.Session.GetString("userID"))))
            };
            return View(shoppingCartController);
        }
        [HttpPost]
        public IActionResult AddCart(int ProductID)
        {
            try
            {
                ShoppingCartViewModel shoppingCartController = new ShoppingCartViewModel()
                {
                    ShoppingCart = _shoppingCartService.GetShoppingCartByUserID(int.Parse(HttpContext.Session.GetString("userID")))

                };
                CartItem cartItem = new CartItem()
                {
                    IDShoppingCart = shoppingCartController.ShoppingCart.ID,
                    IDProduct = ProductID,
                    Quantity = 1
                };
                _shoppingCartService.AddOrUpdate(cartItem);
                return Json(new { isSuccess = true });
            }
            catch (Exception ex)
            {

                return Json(new { isSuccess = false,Message=ex.Message });
            }


           
        }
        [HttpPost]
        public IActionResult RemoveItem(int ProductID)
        {
            try
            {
                ShoppingCartViewModel shoppingCartController = new ShoppingCartViewModel()
                {
                    CartItems = _shoppingCartService.GetShoppingCartItems(_shoppingCartService.GetShoppingCartByUserID(int.Parse(HttpContext.Session.GetString("userID")))),
                    ShoppingCart = _shoppingCartService.GetShoppingCartByUserID(int.Parse(HttpContext.Session.GetString("userID")))

                };
                CartItem cartItem = new CartItem()
                {
                    IDShoppingCart = shoppingCartController.ShoppingCart.ID,
                    IDProduct = ProductID,
                    Quantity = shoppingCartController.CartItems.Where(x => x.ShoppingCartID == shoppingCartController.ShoppingCart.ID && x.ProductID == ProductID).FirstOrDefault().Quantity
                };
                _shoppingCartService.RevomeItem(cartItem);
                return Json(new { isSuccess = true });
            }
            catch (Exception ex)
            {

                return Json(new { isSuccess = false, Message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult CloseShoppingCart()
        {
            try
            {
                ShoppingCartViewModel shoppingCartController = new ShoppingCartViewModel()
                {
                    ShoppingCart = _shoppingCartService.GetShoppingCartByUserID(int.Parse(HttpContext.Session.GetString("userID")))

                };
                ShoppingCart shoppingCart = shoppingCartController.ShoppingCart;
                shoppingCart.IsClosed = true;

                _shoppingCartService.CloseShoppingCart(shoppingCart);
                return Json(new { isSuccess = true });
            }
            catch (Exception ex)
            {

                return Json(new { isSuccess = false, Message = ex.Message });
            }


        }
    }
}
