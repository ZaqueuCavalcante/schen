namespace Schen.Code;

public class Tarefa
{
    public string Name { get; set; }
    public int ArrivalInstant { get; set; }
    public int BurstTime { get; set; }

    public int StartInstant { get; set; }
    public int WaitingTime { get; set; } // = StartInstant - ArrivalInstant
    public int CpuTime { get; set; }

    public int CompletionInstant { get; set; }
    public int TurnAroundTime { get; set; } // = CompletionInstant - ArrivalInstant
}
