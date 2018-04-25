using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalkulatorKalorii.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Producer { get; set; }
        public int Calories { get; set; }

        public virtual int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        public virtual int MacronutrientId { get; set; }
        public virtual Macronutrient Macronutrient { get; set; }
    }
}
