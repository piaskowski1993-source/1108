using System.Threading;
using drone;
using drone.ThreadRace;
using drone.AsyncFlow;
using drone.Presentation;

Console.WriteLine("Welcome to the Drone Race");
Console.WriteLine(" a) Del A -Thread Race (Thread + Join)");
Console.WriteLine(" b) Del B -Async orchestration (async/ await + Task.WhenAll)");
Console.WriteLine("Choose: ");

var choice = Console.ReadLine();
if (choice == "a")
{ RunDelA();}
else if (choice == "b")
{ await RunDelB();}
else
{Console.WriteLine("Unknown Choice.");}

static void RunDelA()
{
    var alpha = new DroneModel("Alpha", maxCheckpoints:5, delayMs:300);
    var bravo = new DroneModel("Bravo", maxCheckpoints:5, delayMs:300);
    var threadAlpha = new Thread (() => DroneThreadWorker.Fly(alpha));
    var threadBravo = new Thread (() => DroneThreadWorker.Fly(bravo));
    threadAlpha.Start();
    threadBravo.Start();
    threadAlpha.Join();
    threadBravo.Join();
    Console.WriteLine("All Drones finished");
}
static async Task RunDelB()
{
    var alpha = new DroneModel("Alpha", maxCheckpoints:10, delayMs: 600);
    var bravo = new DroneModel("Bravo", maxCheckpoints:10, delayMs: 600);
    var charlie = new DroneModel("Charlie", maxCheckpoints:10, delayMs: 600);
    var board = new DroneBoard(new []{ alpha.Name, bravo.Name, charlie.Name});

    try
    {
        await Task.WhenAll(
            DroneAsyncWorker.FlyAsync(alpha,board),
            DroneAsyncWorker.FlyAsync(bravo, board),
            DroneAsyncWorker.FlyAsync(charlie,board));
            board.MoveCursorBelowBoard();
            Console.WriteLine("All drones finished.");
    }

    catch (Exception ex)
    {
        board.MoveCursorBelowBoard();
        Console.WriteLine($"Flight orchestration failed : {ex.Message}");
    }
}