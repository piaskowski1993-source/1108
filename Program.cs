using drone;
using drone.AsyncFlow;
using drone.Presentation;

var alpha = new DroneModel("Alpha", maxCheckpoints: 10, delayMs: 600);
var bravo = new DroneModel("Bravo", maxCheckpoints: 10, delayMs: 600);
var charlie = new DroneModel("Charlie", maxCheckpoints: 10, delayMs: 600);
var board = new DroneBoard(new[] {alpha.Name, bravo.Name, charlie.Name});
try
{
    await Task .WhenAll( DroneAsyncWorker.FlyAsync(alpha, board), 
                         DroneAsyncWorker.FlyAsync(bravo, board),
                         DroneAsyncWorker.FlyAsync(charlie, board));
    board.MoveCursorBelowBoard();
    Console.WriteLine("All drones finished");

}
catch (Exception ex)
{
    board.MoveCursorBelowBoard();
    Console.WriteLine($"Flight orchestration failed :{ex.Message}");
}