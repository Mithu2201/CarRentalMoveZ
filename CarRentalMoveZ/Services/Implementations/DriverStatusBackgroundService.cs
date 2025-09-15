using CarRentalMoveZ.Repository.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalMoveZ.Services.Implementations
{
    public class DriverStatusBackgroundService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public DriverStatusBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Run immediately and then every 1 minute
            _timer = new Timer(UpdateDriverStatus, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        private void UpdateDriverStatus(object state)
        {
            // Create a scope for scoped services
            using (var scope = _serviceProvider.CreateScope())
            {
                var driverRepository = scope.ServiceProvider.GetRequiredService<IDriverRepository>();
                driverRepository.UpdateDriverStatusBasedOnLastBooking();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
