using System.Threading;
using drone;
namespace drone.ThreadRace;

public static class DroneThreadWorker
{
    public static void Fly (DroneModel drone)
    {
    Console.WriteLine($"[{drone.Name}] starting flight on thread {Environment.CurrentManagedThreadId}, {drone.MaxCheckpoints} checkpoints");

    for (int checkpoint = 0; checkpoint <= drone.MaxCheckpoints; checkpoint++)
    {
        Console.WriteLine ($"[{drone.Name}] checkpoint {checkpoint}/ {drone.MaxCheckpoints}");
        
        if (checkpoint < drone.MaxCheckpoints)
        {Thread.Sleep(drone.DelayMs);}
    }
    Console.WriteLine ($"[{drone.Name}] flight complete");
}
}
