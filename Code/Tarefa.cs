namespace Schen.Code;

public class Tarefa
{
    public string Name { get; set; }
    public int ArrivalTime { get; set; }
    public int BurstTime { get; set; }

    public int WaitingTime { get; set; }
    public int StartTime { get; set; }
    public int CpuTime { get; set; }
}
