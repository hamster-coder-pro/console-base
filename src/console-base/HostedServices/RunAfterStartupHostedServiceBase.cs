using Microsoft.Extensions.Hosting;

public abstract class RunAfterStartupHostedServiceBase : HostedServiceBase
{
    private IHostApplicationLifetime HostApplicationLifetime { get; }

    protected RunAfterStartupHostedServiceBase(IHostApplicationLifetime hostApplicationLifetime)
    {
        HostApplicationLifetime = hostApplicationLifetime;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        Task.Delay(Timeout.InfiniteTimeSpan, HostApplicationLifetime.ApplicationStarted).ContinueWith(async _ =>
        {
            await Task.Delay(100, cancellationToken);
            await ExecuteAsync(cancellationToken);
        }, TaskContinuationOptions.OnlyOnCanceled);
        return Task.CompletedTask;
    }

    protected abstract Task ExecuteAsync(CancellationToken cancellationToken);
}