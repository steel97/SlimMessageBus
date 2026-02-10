namespace SlimMessageBus.Host.Nats;

public static class NatsHandlerBuilderExtensions
{
    /// <summary>
    /// Configure queue name that incoming requests (<see cref="TRequest"/>) are expected on.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="queue">Queue name</param>
    /// <returns></returns>
    public static HandlerBuilder<TRequest, TResponse> Queue<TRequest, TResponse>(this HandlerBuilder<TRequest, TResponse> builder, string queue)
    {
        if (builder is null) throw new ArgumentNullException(nameof(builder));

        builder.Path(queue);
        builder.ConsumerSettings.PathKind = PathKind.Queue;
        return builder;
    }
}