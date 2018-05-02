using KalkulatorKalorii.Models.Database;
using KalkulatorKalorii.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalkulatorKalorii.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public int AddProduct(Product product, ProductType productType, Macronutrient macronutrient)
        {
            if(product == null)
            {
                throw new Exception("Product object cannot by null.");
            }

            if (productType == null)
            {
                throw new Exception("ProductType object cannot by null.");
            }

            if (macronutrient == null)
            {
                throw new Exception("Macronutrient object cannot by null.");
            }

            product.Id = 0;
            product.ProductType = productType;
            product.ProductTypeId = productType.ProductTypeId;

            product.Macronutrient = macronutrient;
            product.MacronutrientId = macronutrient.MacronutrientId;

            _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();

            return product.Id;
        }

        public void DeleteProduct(Product product, ProductType productType, Macronutrient macronutrient)
        {
            if (product == null)
            {
                throw new Exception("Product object cannot by null.");
            }

            if (productType == null)
            {
                throw new Exception("ProductType object cannot by null.");
            }

            if (macronutrient == null)
            {
                throw new Exception("Macronutrient object cannot by null.");
            }

            _databaseContext.Products.Remove(product);
            _databaseContext.SaveChanges();

            _databaseContext.ProductTypes.Remove(productType);
            _databaseContext.SaveChanges();

            _databaseContext.Macronutrients.Remove(macronutrient);
            _databaseContext.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _databaseContext.Products.ToList();
        }

        public Product GetProduct(int productId)
        {
            if(productId <= 0)
            {
                throw new Exception("Id cannot by less than 0.");
            }

            return _databaseContext.Products.
                Where(product => product.Id == productId).
                FirstOrDefault();
        }

        public int UpdateProduct(Product product)
        {
            if(product == null)
            {
                throw new Exception("Product object cannot by null");
            }

            _databaseContext.Products.Update(product);
            _databaseContext.SaveChanges();

            return product.Id;
        }
    }
}
