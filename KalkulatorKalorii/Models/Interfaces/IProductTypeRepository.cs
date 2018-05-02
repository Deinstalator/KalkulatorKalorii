using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalkulatorKalorii.Models.Interfaces
{
    public interface IProductTypeRepository
    {
        int AddProductType(ProductType productType);
        ProductType GetProductType(int productTypeId);
    }
}
