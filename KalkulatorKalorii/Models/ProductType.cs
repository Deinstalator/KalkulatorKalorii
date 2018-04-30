namespace KalkulatorKalorii.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public Type Type { get; set; }
        public Content Content { get; set; }
        public bool IsVegan { get; set; }
    }

    public enum Type
    {
        desserts = 0,
        meat = 1,
        dairy_products = 2,
        nuts = 3,
        breads = 4,
        vegetables = 5,
        fish_seafood = 6,
        other = 7
    }

    public enum Content
    {
        HighFat = 0,
        HighCarbs = 1,
        HighProtein = 2
    }
}