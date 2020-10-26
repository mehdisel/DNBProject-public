using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DNBProject.BLL.ProductManagement;
using DNBProject.Entities.Entity;
using DNBProject.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList.Core;

namespace DNBProject.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        public IActionResult Index(int page = 1, int pageSize = 18)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("userID")))
            {
                return RedirectToAction("Login", "User");
            }
            ProductListViewModel productListViewModel = new ProductListViewModel()
            {
                PagedList = new PagedList<Product>(_productService.GetAll(), page, pageSize)

            };

            return View("index", productListViewModel.PagedList);
        }
        public IActionResult Products(int page = 1, int pageSize = 18)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("userID")))
            {
                return RedirectToAction("Login", "User");
            }
            ProductListViewModel productListViewModel = new ProductListViewModel()
            {
                PagedList = new PagedList<Product>(_productService.GetAll(), page, pageSize)
            };

            return View("Products", productListViewModel.PagedList);
        }
        [HttpPost]
        public IActionResult DeleteItem(int ProductID)
        {
            try
            {
                _productService.DeleteProduct(ProductID);
                return Json(new { IsSuccess = true });
            }
            catch (Exception ex)
            {

                return Json(new { IsSuccess = false, Message = ex.Message }); ;

            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("userID")))
            {
                return RedirectToAction("Login", "User");
            }
            ProductListViewModel productListViewModel = new ProductListViewModel()
            {
                Product = _productService.GetProduct(id)
            };  
        
            return View(productListViewModel);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            try
            {
                _productService.Update(product);
                return Json(new { isSuccess=true });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false,Message=ex.Message });
            }
            
     
        }

    }
}
