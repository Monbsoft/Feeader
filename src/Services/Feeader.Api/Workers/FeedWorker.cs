using MediatR;
using Monbsoft.Feeader.Application.UseCases.UpdateFeed;

namespace Monbsoft.Feeader.Api.Workers
{
    public class FeedWorker : BackgroundService
    {
        private readonly TimeSpan _delay = TimeSpan.FromHours(1);
        private readonly ILogger<FeedWorker> _logger;
        private readonly IServiceScopeFactory _services;

        public FeedWorker(IServiceScopeFactory services, ILogger<FeedWorker> logger)
        {
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting feed worker...");

            while(!stoppingToken.IsCancellationRequested)
            {
                using(var scope = _services.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    int count = await mediator.Send<int>(new UpdateFeedsCommand());
                    _logger.LogInformation("{Count} articles created", count);
                }
                await Task.Delay(_delay, stoppingToken);
            }
        }
    }
}
