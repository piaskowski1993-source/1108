namespace drone.Presentation;
public class DroneBoard
{
    private readonly Dictionary<string, int> _rows = new();
    private readonly int _StartRow;
    private readonly object _lock = new();
    public DroneBoard (IReadOnlyList <string> droneNames)
    {
        _StartRow = Console.CursorTop;
        for (int i = 0; i < droneNames.Count ; i++)
        {
            _rows [droneNames[i]] = i;
            Console.WriteLine();
        }
    }
    public void ReportCheckpoint (string DroneName, int checkpoint, int maxCheckpoints)
    {
        lock (_lock)
        {
            var track = new char [maxCheckpoints +1];
            for (int i = 0; i < track.Length; i++)
            {
                if (i< checkpoint) track [i] = '*';
                else if ( i == checkpoint) track [i] = '>';
                else track [i] = '-';
            }
            var status = checkpoint >= 1? "  (connected)" : "";
            var line = $"{DroneName, -10} [{new string (track)}] {checkpoint}/{maxCheckpoints}{status}";

            Console.SetCursorPosition(0, _StartRow + _rows [DroneName]);
            Console.WriteLine (line.PadRight(60));          
        }
    }
    public void ReportFailure( string droneName, int checkpoint, int maxCheckpoint)
    {
        lock (_lock)
        {
            var track = new char [maxCheckpoint +1];
            for (int i = 0; i < track.Length; i++)
        {
            if( i< checkpoint) track [i] = '*';
            else if (i == checkpoint) track [i] = 'x';
            else track [i] = '-';
        }
        var line = $"{droneName, -10} [{new string (track)}] {checkpoint}/{maxCheckpoint} (failed)";
        Console.SetCursorPosition(0, _StartRow + _rows [droneName]);
        Console.Write(line.PadRight(60));
        }
    }

        public void MoveCursorBelowBoard()
    {
        lock(_lock)
        {
            Console.SetCursorPosition(0, _StartRow + _rows.Count);
        }

    }
}