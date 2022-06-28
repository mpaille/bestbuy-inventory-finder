using Mpaille.BestBuyInventoryFinder.Domain;
using Mpaille.BestBuyInventoryFinder.Domain.Services;

namespace Mpaille.BestBuyInventoryFinder
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ApplicationSettings _applicationSettings;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory, ApplicationSettings applicationSettings)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _applicationSettings = applicationSettings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker started at: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug("Worker running at: {time}", DateTimeOffset.Now);

                using var scope = _serviceScopeFactory.CreateScope();

                var bestBuyInventoryFinderService = scope.ServiceProvider.GetRequiredService<IBestBuyAvailabilityService>();

                await bestBuyInventoryFinderService.CheckAvailabilitiesAsync(_applicationSettings.Skus, stoppingToken);

                await Task.Delay(TimeSpan.FromSeconds(_applicationSettings.DelayInSeconds), stoppingToken);
            }
        }
    }
}