using System;
using MediatR;

namespace AzureFunction.SubscriberSamples.Application.Commands.Id
{
    public sealed class IdSampleSubscriberCommand : IRequest
    {
        public IdSampleSubscriberCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
