namespace Laptop.Models
{
    public class LaptopObject
    {
        public int Id { get; set; }

        public string Model { get; set; } = null!;

        public int BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        public int Price { get; set; }

        public int Year { get; set; }

    }
}
