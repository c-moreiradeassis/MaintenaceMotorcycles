using Application.Interfaces;
using Domain.Configuration;
using Microsoft.Extensions.Options;

namespace Worker
{
    public sealed class Executor : BackgroundService
    {
        private readonly ILogger<Executor> _logger;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IServiceProvider _serviceProvider;
        private readonly AlertOptions _alertOptions;
        private readonly SmtpOptions _smtpOptions;

        public Executor(ILogger<Executor> logger,
            IHostApplicationLifetime hostApplicationLifetime,
            IServiceProvider serviceProvider,
            IOptions<AlertOptions> alertOptions,
            IOptions<SmtpOptions> smtpOptions)
        {
            _logger = logger;
            _hostApplicationLifetime = hostApplicationLifetime;
            _serviceProvider = serviceProvider;
            _alertOptions = alertOptions.Value;
            _smtpOptions = smtpOptions.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    ClientService _service = scope.ServiceProvider.GetRequiredService<ClientService>();

                    var clients = await _service.GetEmails();

                    if (clients.Any())
                    {
                        MaintenanceService _maintenaceService = scope.ServiceProvider.GetRequiredService<MaintenanceService>();
                        EmailService _emailService = scope.ServiceProvider.GetRequiredService<EmailService>();

                        var alerts = _alertOptions.CreateAlerts();

                        foreach (var client in clients)
                        {
                            foreach (var alert in alerts)
                            {
                                var dateAlert = _maintenaceService.GetNextMaintenanceDate(alert);

                                var maintenances = await _maintenaceService.GetMaintenancesByClient(client.Id, dateAlert);

                                if (maintenances.Any())
                                {
                                    _emailService.SendEmail(client.Email, _smtpOptions, maintenances.ToList());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                _hostApplicationLifetime.StopApplication();
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                $"{nameof(Executor)} is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}