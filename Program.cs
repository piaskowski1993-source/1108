using drone;
using drone.AsyncFlow;

var alpha = new DroneModel("Alpha", maxCheckpoints: 5, delayMs: 300);
var bravo = new DroneModel("Bravo", maxCheckpoints: 5, delayMs: 300);
var charlie = new DroneModel("Charlie", maxCheckpoints: 5, delayMs: 300);

try
{
    await Task .WhenAll( DroneAsyncWorker.FlyAsync(alpha), 
                         DroneAsyncWorker.FlyAsync(bravo),
                         DroneAsyncWorker.FlyAsync(charlie));
    Console.WriteLine("All drones finished");
}
catch (Exception ex)
{
    Console.WriteLine($"Flight orchestration failed :{ex.Message}");
}