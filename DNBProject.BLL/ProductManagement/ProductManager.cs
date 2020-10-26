using System;
using System.Text;
using DNBProject.Entities.Entity;
using System.Linq;
using System.Collections.Generic;
using DNBProject.DAL.EF.Interfaces;

namespace DNBProject.BLL.ProductManagement
{
    public class ProductManager:IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAllList()
        {
            return _productDal.GetAllList().Where(x=>x.IsDeleted==false).ToList();
        }
        public IEnumerable<Product> GetAll()
        {
            return _productDal.GetAll().Where(x=>x.IsDeleted==false).AsQueryable();
        }
        public void DeleteProduct(int ProductID)
        {
            _productDal.Delete(new Product() { ID = ProductID });
        }
        public Product GetProduct(int id)
        {
            return _productDal.GetByCondition(x=>x.ID==id);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
