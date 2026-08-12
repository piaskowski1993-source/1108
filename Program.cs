using System.Threading;
using drone;
using drone.ThreadRace;

var alpha = new DroneModel ("Alpha", maxCheckpoints : 5, delayMs: 300);
var bravo = new DroneModel ("Bravo", maxCheckpoints :5, delayMs: 300);

var threadAlpha = new Thread (() => DroneThreadWorker.Fly(alpha));
var threadBravo = new Thread (() => DroneThreadWorker.Fly(bravo));

threadAlpha.Start();
threadBravo.Start();

Console.WriteLine("All drones finished.");