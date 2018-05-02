using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalkulatorKalorii.Models.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProduct(int productId);
        int AddProduct(Product product, ProductType productType, Macronutrient macronutrient);
        int UpdateProduct(Product product);
        void DeleteProduct(Product product, ProductType productType, Macronutrient macronutrient);
    }
}
