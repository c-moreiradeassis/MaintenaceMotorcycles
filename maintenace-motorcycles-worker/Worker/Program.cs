using Application.Interfaces;
using Application.Services;
using Data.Dapper;
using Domain.Configuration;
using Domain.Repository;
using Infra.Interfaces;
using Infra.Services;
using Worker;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.Configure<AlertOptions>(hostContext.Configuration.GetSection("Parameters:Alert"));
        services.Configure<SmtpOptions>(hostContext.Configuration.GetSection("Parameters:Smtp"));
        services.Configure<ConnectionStringsOptions>(hostContext.Configuration.GetSection("ConnectionStrings"));

        services.AddScoped<ClientService, ClientServiceImp>();
        services.AddScoped<MaintenanceService, MaintenanceServiceImp>();
        services.AddScoped<EmailService, EmailServiceImp>();

        services.AddScoped<SenderEmail, SenderEmailImp>();

        services.AddSingleton<DapperContext>();
        services.AddScoped<ClientRepository, ClientRepositoryImp>();
        services.AddScoped<MaintenanceRepository, MaintenanceRepositoryImp>();

        services.AddHostedService<Executor>();
    });

IHost host = builder.Build();
host.Run();
