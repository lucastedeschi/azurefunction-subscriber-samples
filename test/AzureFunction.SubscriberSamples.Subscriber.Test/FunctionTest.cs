using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AzureFunction.SubscriberSamples.Subscriber.Test
{
    public class FunctionTest
    {
        private readonly Function _function;
        private readonly Mock<ILogger<Function>> _logger;

        public FunctionTest()
        {
            _logger = new Mock<ILogger<Function>>();

            _function = new Function(new Mock<IMediator>().Object, _logger.Object);
        }

        [Fact]
        public async Task RunMessageSampleSubscriber_GivenAValidTextMessage_ShouldNotLogAnError()
        {
            await _function.RunMessageSampleSubscriber("message");

            _logger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                    Times.Never());
        }

        [Fact]
        public async Task RunMessageSampleSubscriber_GivenAnEmptyMessage_ShouldLogAnError()
        {
            await _function.RunMessageSampleSubscriber(string.Empty);

            _logger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                    Times.Once());
        }

        [Fact]
        public async Task RunIdSampleSubscriberCommand_GivenAValidGuidMessage_ShouldNotLogAnError()
        {
            await _function.RunIdSampleSubscriberCommand(Guid.NewGuid().ToString());

            _logger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                    Times.Never());
        }

        [Fact]
        public async Task RunIdSampleSubscriberCommand_GivenAnInvalidGuidMessage_ShouldLogAnError()
        {
            await _function.RunIdSampleSubscriberCommand("message");

            _logger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                    Times.Once());
        }

        [Fact]
        public async Task RunIdSampleSubscriberCommand_GivenAnEmptyMessage_ShouldLogAnError()
        {
            await _function.RunIdSampleSubscriberCommand(string.Empty);

            _logger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                    Times.Once());
        }
    }
}
