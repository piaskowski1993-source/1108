using drone.Presentation;

namespace drone.AsyncFlow;
public static class DroneAsyncWorker
{
    public static async  Task FlyAsync (DroneModel drone, DroneBoard board)
    {
        for (int checkpoint = 0; checkpoint <= drone.MaxCheckpoints; checkpoint++)

        {
            board.ReportCheckpoint(drone.Name, checkpoint, drone.MaxCheckpoints);
            
            if (drone.Name == "Charlie" && checkpoint == 2)
            {
            board.ReportFailure(drone.Name, checkpoint, drone.MaxCheckpoints);
                throw new InvalidOperationException ($"[{drone.Name}] engine failure at checkpoint {checkpoint}");
            }
            if (checkpoint < drone.MaxCheckpoints)
            {
                await Task .Delay(drone.DelayMs);
            }
        }
        }
}