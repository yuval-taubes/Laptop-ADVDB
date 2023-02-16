namespace Laptop.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public Brand Brand { get; set; }

        public int Price { get; set; }

        public int Year { get; set; }

        public Laptop(int id, string model, Brand brand, int price, int year)
        {
            Id = id;
            Model = model;
            Brand = brand;
            Price = price;
            Year = year;
        }

    }
}
