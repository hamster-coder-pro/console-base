internal class ApplicationBootstrapper : IApplicationBootstrapper
{
    public ApplicationBootstrapper(/* Inject needed service here */)
    {
    }

    public Task ExecuteAsync(CancellationToken cancellationToken)
    {
        /* put your code here */
        Console.WriteLine("Hello World!");
        return Task.CompletedTask;
    }
}