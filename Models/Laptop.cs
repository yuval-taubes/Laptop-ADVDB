namespace Laptop.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        public string Model { get; set; } = null!;

        public int BrandId { get; set; }

        public int Price { get; set; }

        public int Year { get; set; }
    }
}
