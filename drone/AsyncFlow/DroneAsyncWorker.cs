namespace drone.AsyncFlow;
public static class DroneAsyncWorker
{
    public static async  Task FlyAsync (DroneModel drone)
    {
        Console.WriteLine($"[{drone.Name}] starting flight, {drone.MaxCheckpoints} checkpoints");
        for (int checkpoint = 0; checkpoint <= drone.MaxCheckpoints; checkpoint++)
        {
            Console.WriteLine($"[{drone.Name}] checkpoint {checkpoint}/{drone.MaxCheckpoints}");
            if (drone.Name == "Charlie" && checkpoint == 2)
            {
                throw new InvalidOperationException ($"[{drone.Name}] engine failure at checkpoint {checkpoint}");
            }
            if (checkpoint < drone.MaxCheckpoints)
            {
                await Task .Delay(drone.DelayMs);
            }
        }
        Console.WriteLine($"[{drone.Name}] flight complete");
        }
}