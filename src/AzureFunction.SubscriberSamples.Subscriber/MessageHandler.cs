using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AzureFunction.SubscriberSamples.Subscriber
{
    internal static class MessageHandler
    {
        public static async Task Handle(Func<Task> body, ILogger logger)
        {
            try
            {
                await body();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                
                throw;
            }
        }
    }
}
