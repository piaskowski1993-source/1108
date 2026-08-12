namespace drone;

public class DroneModel
{
    public string Name {get;}
    public int MaxCheckpoints {get;}
    public int DelayMs {get;}
    public DroneModel (string name, int maxCheckpoints, int delayMs)
    {
    if (string. IsNullOrWhiteSpace(name))
    throw new ArgumentException ("Drone must have a name.", nameof(name));

    if (maxCheckpoints <= 0 )
    throw new ArgumentException ("MaxCheckpoints must be positive.", nameof(maxCheckpoints));

    if (delayMs <0)
    throw new ArgumentException ("DelayMs cannot be negative.",nameof(delayMs));

    Name = name;
    MaxCheckpoints = maxCheckpoints;
    DelayMs = delayMs;

    }
}
