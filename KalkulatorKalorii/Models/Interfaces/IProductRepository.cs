using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalkulatorKalorii.Models.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetProduct(int productId);
    }
}
