using System;
using System.Threading.Tasks;
using AzureFunction.SubscriberSamples.Application.Commands.Id;
using AzureFunction.SubscriberSamples.Application.Commands.Message;
using AzureFunction.SubscriberSamples.Subscriber;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunction.SubscriberSamples
{
    public class Function
    {
        private readonly IMediator _mediator;
        private readonly ILogger<Function> _logger;

        public Function(IMediator mediator, ILogger<Function> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [FunctionName("MessageSampleSubscriber")]
        public async Task RunMessageSampleSubscriber([ServiceBusTrigger("serviceBus-queueName", Connection = "ServiceBusQueueConnectionString")]string message)
        {
            await MessageHandler.Handle(async () => 
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    _logger.LogError($"The message '{message}' must not be empty");

                    return;
                }

                await _mediator.Send(new MessageSampleSubscriberCommand(message));

            }, _logger);
        }

        [FunctionName("IdSampleSubscriberCommand")]
        public async Task RunIdSampleSubscriberCommand([QueueTrigger("storageQueue-queueName", Connection = "StorageQueueConnectionString")] string message)
        {
            await MessageHandler.Handle(async () =>
            {
                if (!Guid.TryParse(message, out var guid))
                {
                    _logger.LogError($"The message '{message}' must be a Guid");

                    return;
                }

                await _mediator.Send(new IdSampleSubscriberCommand(guid));

            }, _logger);
        }
    }
}
