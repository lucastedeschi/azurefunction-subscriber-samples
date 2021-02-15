using System.Threading;
using System.Threading.Tasks;
using AzureFunction.SubscriberSamples.Application.Commands.Message.Notifications;
using MediatR;

namespace AzureFunction.SubscriberSamples.Application.Commands.Id
{
    public sealed class IdSampleSubscriberCommandHandler : IRequestHandler<IdSampleSubscriberCommand>
    {
        private readonly IMediator _mediator;

        public IdSampleSubscriberCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(IdSampleSubscriberCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new IdReceivedSampleNotification(), cancellationToken);

            return Unit.Value;
        }
    }
}
