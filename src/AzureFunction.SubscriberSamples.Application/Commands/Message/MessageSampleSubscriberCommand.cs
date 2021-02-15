using MediatR;

namespace AzureFunction.SubscriberSamples.Application.Commands.Message
{
    public sealed class MessageSampleSubscriberCommand : IRequest
    {
        public MessageSampleSubscriberCommand(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
