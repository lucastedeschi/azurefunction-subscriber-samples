using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AzureFunction.SubscriberSamples.Application.Commands.Message.Notifications
{
    public sealed class MessageReceivedSampleNotificationHandler : INotificationHandler<MessageReceivedSampleNotification>
    {
        public Task Handle(MessageReceivedSampleNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
