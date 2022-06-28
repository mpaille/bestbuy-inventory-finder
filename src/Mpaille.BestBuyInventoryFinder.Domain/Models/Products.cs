namespace Mpaille.BestBuyInventoryFinder.Domain.Models
{
    public class Products
    {
        public IEnumerable<Availability> Availabilities { get; set; } = Enumerable.Empty<Availability>();
    }
}
