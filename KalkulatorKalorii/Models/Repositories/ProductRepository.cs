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

        public List<Product> GetAll()
        {
            return _databaseContext.Products.ToList();
        }

        public Product GetProduct(int productId)
        {
            return _databaseContext.Products.
                Where(product => product.Id == productId).
                FirstOrDefault();
        }
    }
}
