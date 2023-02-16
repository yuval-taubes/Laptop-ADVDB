namespace Laptop.Models.ViewModels
{
    public class LaptopCRUD
    { 
        public string Model { get; set; } = null!;

        public int BrandId { get; set; }

        public int Price { get; set; }

        public int Year { get; set; }

        public List<Brand> Brands { get; set; }
    }
}
