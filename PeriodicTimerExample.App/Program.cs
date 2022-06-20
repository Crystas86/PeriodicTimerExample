using PeriodicTimerExample.App;

Console.WriteLine("Press any button to start task");
Console.ReadKey();

var task = new BackgroundTask(TimeSpan.FromMilliseconds(1000));
task.Start();

Console.WriteLine("Press any button again to stop task");
Console.ReadKey();

await task.StopAsync();