using AzureFunction.SubscriberSamples;
using AzureFunction.SubscriberSamples.CrossCutting.IoC;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace AzureFunction.SubscriberSamples
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDependencies();

            builder.Services.AddLogging();
        }
    }
}
