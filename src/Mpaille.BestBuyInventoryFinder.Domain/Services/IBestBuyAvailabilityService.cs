namespace Mpaille.BestBuyInventoryFinder.Domain.Services
{
    public interface IBestBuyAvailabilityService
    {
        Task CheckAvailabilitiesAsync(string skus, CancellationToken cancellation);
    }
}
