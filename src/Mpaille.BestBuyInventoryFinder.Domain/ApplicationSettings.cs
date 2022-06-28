namespace Mpaille.BestBuyInventoryFinder.Domain
{
    public class ApplicationSettings
    {
        public string BestBuyApiBaseAddress { get; init; } = string.Empty;
        public string Skus { get; init; } = string.Empty;
        public int DelayInSeconds { get; init; }
    }
}
