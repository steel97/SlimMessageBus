namespace SlimMessageBus.Host;

public interface IConsumerControl
{
    /// <summary>
    /// Starts message consumption
    /// </summary>
    /// <returns></returns>
    Task Start(string method = "unknown");

    /// <summary>
    /// Indicates whether the consumers are started.
    /// </summary>
    bool IsStarted { get; }

    /// <summary>
    /// Stops message consumption
    /// </summary>
    /// <returns></returns>
    Task Stop(string method = "unknown");
}
