
using Microsoft.Extensions.DependencyInjection;
using StartupCompanyManager.Application;
using StartupCompanyManager.Infrastructure.Configurations;

IServiceProvider serviceProvider = ServicesConfiguration.ConfigureServices();
IStartupCompanyManagerApplication startupCompanyApplication = serviceProvider.GetService<IStartupCompanyManagerApplication>()!;
startupCompanyApplication.Run();