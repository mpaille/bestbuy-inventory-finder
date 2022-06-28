namespace Mpaille.BestBuyInventoryFinder.Domain.Models
{
    public class Availability
    {
        public Shipping Shipping { get; set; } = new Shipping();
        public string Sku { get; set; } = string.Empty;
    }
}
