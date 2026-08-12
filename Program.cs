using drone;
using drone.AsyncFlow;

var alpha = new DroneModel("Alpha", maxCheckpoints: 5, delayMs: 300);
var bravo = new DroneModel("Bravo", maxCheckpoints: 5, delayMs: 300);

try
{
    await Task .WhenAll( DroneAsyncWorker.FlyAsync(alpha), DroneAsyncWorker.FlyAsync(bravo));
    Console.WriteLine("All drones finished");
}
catch (Exception ex)
{
    Console.WriteLine($"Flight orchestrationf failed :{ex.Message}");
}