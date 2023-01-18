public interface IApplicationBootstrapper
{
    Task ExecuteAsync(CancellationToken cancellationToken);
}
