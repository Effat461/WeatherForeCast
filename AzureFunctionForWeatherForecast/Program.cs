using AzureFunctionForWeatherForecast.Services.Concrete;
using AzureFunctionForWeatherForecast.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(builder =>
    {
        builder.AddTransient<IAzureFunctionService, AzureFunctionService>();
    })
    .Build();
host.Run();
