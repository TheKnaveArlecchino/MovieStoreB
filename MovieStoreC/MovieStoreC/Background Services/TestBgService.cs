
namespace MovieStoreC.Background_Services
{
    public class TestBgService : BackgroundService

    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)

        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"Job executed:{DateTime.Now}");

                await Task.Delay(10000, stoppingToken);

                Console.WriteLine("MethodAborted");
            }
        }
    }
}