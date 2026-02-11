namespace SlimMessageBus.Host.Nats.Test.Config;


public class NatsConsumerBuilderExtensionsTests
{
    private class TestMessage { }

    private readonly MessageBusSettings _settings;
    private readonly ConsumerBuilder<TestMessage> _consumerBuilder;

    public NatsConsumerBuilderExtensionsTests()
    {
        _settings = new MessageBusSettings();
        _consumerBuilder = new ConsumerBuilder<TestMessage>(_settings);
    }

    #region Queue Tests

    [Fact]
    public void When_Queue_Given_NullBuilder_Then_ThrowsArgumentNullException()
    {
        // Act
        var action = () => NatsConsumerBuilderExtensions.Queue<TestMessage>(null, "test-queue");

        // Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName("natsBuilder");
    }

    [Fact]
    public void When_Queue_Given_NullQueueName_Then_ThrowsArgumentNullException()
    {
        // Act
        var action = () => _consumerBuilder.Queue(null);

        // Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName("natsQueue");
    }

    [Fact]
    public void When_Queue_Given_ValidParameters_Then_SetsPathAndPathKind()
    {
        // Arrange
        var queueName = "test-queue";

        // Act
        var result = _consumerBuilder.Queue(queueName);

        // Assert
        result.Should().BeSameAs(_consumerBuilder);
        _consumerBuilder.ConsumerSettings.Path.Should().Be(queueName);
        _consumerBuilder.ConsumerSettings.PathKind.Should().Be(PathKind.Queue);
    }

    #endregion
}
