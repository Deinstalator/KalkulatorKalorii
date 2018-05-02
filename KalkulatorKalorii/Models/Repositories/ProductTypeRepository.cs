using KalkulatorKalorii.Models.Database;
using KalkulatorKalorii.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalkulatorKalorii.Models.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductTypeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; 
        }

        public int AddProductType(ProductType productType)
        {
            if(productType == null)
            {
                throw new Exception("ProductType object cannot be null.");
            }

            _databaseContext.ProductTypes.Add(productType);
            _databaseContext.SaveChanges();

            return productType.ProductTypeId;
        }

        public ProductType GetProductType(int productTypeId)
        {
            if(productTypeId <= 0)
            {
                throw new Exception("Id cannot by less than 0.");
            }

            return _databaseContext.ProductTypes.FirstOrDefault(productType => productType.ProductTypeId == productTypeId);

        }
    }
}
