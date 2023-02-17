namespace Laptop.Models.ViewModels
{
    public class LaptopByBrandOrderingViewModel
    {
        public int BrandChoice { get; set; }

        public List<Brand> Brands { get; set; } = new();

        public List<string> OrderingChoices = new List<string>()
        {
            "Order By Price Ascending",
            "Order By Price Descending",
            "Order By Year Ascending",
            "Order By Year Descending"
        };
        public string OrderChoice { get; set; }

        public List<LaptopObject> ResultLaptops { get; set; } = new();
    }
}
