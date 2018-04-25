namespace KalkulatorKalorii.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public Type Type { get; set; }
        public ProductContent Content { get; set; }
        public bool IsVegan { get; set; }
    }

    public enum Type
    {
        desserts,
        meat,
        dairy_products,
        nuts,
        breads,
        spices_seasonings,
        fish_seafood,
        candies
    }

    public enum ProductContent
    {
        HighFat = 0,
        HighCarbs = 1,
        HighProtein = 2
    }
}