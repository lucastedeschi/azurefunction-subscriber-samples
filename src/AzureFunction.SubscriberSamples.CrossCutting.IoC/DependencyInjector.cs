using AzureFunction.SubscriberSamples.Application.Commands.Message;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AzureFunction.SubscriberSamples.CrossCutting.IoC
{
    public static class DependencyInjector
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MessageSampleSubscriberCommand).Assembly);
        }
    }
}
