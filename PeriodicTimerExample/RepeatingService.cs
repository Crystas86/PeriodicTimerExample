namespace PeriodicTimerExample
{
    public class RepeatingService : BackgroundService
    {
        private readonly PeriodicTimer _timer = new(TimeSpan.FromMilliseconds(1000));

        private readonly ILogger<RepeatingService> _logger;

        public RepeatingService(ILogger<RepeatingService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (await _timer.WaitForNextTickAsync(stoppingToken)
                && !stoppingToken.IsCancellationRequested)
            {
                await DoWorkAsync();
            }
        }

        private static async Task DoWorkAsync()
        {
            Console.WriteLine(DateTime.Now.ToString("O"));
            await Task.Delay(500);
        }
    }
}
