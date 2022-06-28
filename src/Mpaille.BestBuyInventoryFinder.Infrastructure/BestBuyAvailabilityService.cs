using Microsoft.Extensions.Logging;
using Mpaille.BestBuyInventoryFinder.Domain.Models;
using Mpaille.BestBuyInventoryFinder.Domain.Services;
using Newtonsoft.Json;

namespace Mpaille.BestBuyInventoryFinder.Infrastructure
{
    internal class BestBuyAvailabilityService : IBestBuyAvailabilityService
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        public BestBuyAvailabilityService(ILogger<BestBuyAvailabilityService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task CheckAvailabilitiesAsync(string skus, CancellationToken cancellationToken)
        {
            using var response = await _httpClient.GetAsync("availability/products?skus=" + skus, cancellationToken);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            var products = JsonConvert.DeserializeObject<Products>(content) ?? throw new InvalidOperationException("The response should not be null.");

            foreach (var product in products.Availabilities)
            {
                if (!product.Shipping.Purchasable) continue;

                _logger.LogCritical("Sku: {sku} is available at: {time} with status: {status}", product.Sku, DateTimeOffset.Now, product.Shipping.Status);
            }
        }
    }
}
