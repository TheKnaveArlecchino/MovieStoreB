
namespace MovieStoreC.Background_Services
{
    public class TestHostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Hosted Service Started...");
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine($"HostedService:{DateTime.Now}");
                    await Task.Delay(10000, cancellationToken);
                }
                return Task.CompletedTask;
            });
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Hosted Service Stop!");

            return Task.CompletedTask;
            
        }
    }
}
