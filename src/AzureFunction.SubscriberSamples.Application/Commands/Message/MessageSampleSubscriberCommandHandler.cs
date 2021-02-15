using System;
using System.Threading;
using System.Threading.Tasks;
using AzureFunction.SubscriberSamples.Application.Commands.Message.Notifications;
using MediatR;

namespace AzureFunction.SubscriberSamples.Application.Commands.Message
{
    public sealed class MessageSampleSubscriberCommandHandler : IRequestHandler<MessageSampleSubscriberCommand>
    {
        private readonly IMediator _mediator;

        public MessageSampleSubscriberCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(MessageSampleSubscriberCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new MessageReceivedSampleNotification(), cancellationToken);

            return Unit.Value;
        }
    }
}
