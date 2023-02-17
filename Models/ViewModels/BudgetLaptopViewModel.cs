namespace Laptop.Models.ViewModels
{
    public class BudgetLaptopViewModel
    {
        public List<LaptopObject> Result { get; set; } = new();

        public int Budget { get; set; }
    }
}
