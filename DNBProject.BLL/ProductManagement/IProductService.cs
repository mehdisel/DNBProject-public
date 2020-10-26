
using DNBProject.Entities.Entity;

using System;
using System.Collections.Generic;
using System.Text;

namespace DNBProject.BLL.ProductManagement
{
    public interface IProductService
    {
        List<Product> GetAllList();
        IEnumerable<Product> GetAll();

        void DeleteProduct(int ProductID);
        Product GetProduct(int id);
        void Update(Product product);
    }
}
