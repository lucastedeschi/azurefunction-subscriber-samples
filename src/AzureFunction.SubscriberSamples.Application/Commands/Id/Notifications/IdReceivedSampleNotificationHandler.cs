using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AzureFunction.SubscriberSamples.Application.Commands.Message.Notifications
{
    public sealed class IdReceivedSampleNotificationHandler : INotificationHandler<IdReceivedSampleNotification>
    {
        public Task Handle(IdReceivedSampleNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
