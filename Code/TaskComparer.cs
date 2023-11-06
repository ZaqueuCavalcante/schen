namespace Schen.Code;

public class TaskComparer : IComparer<Tarefa>
{
    // X eh mais prioritario q Y -> retorna -1
    // X e Y tem a mesma prioridade -> retorna 0 
    // Y eh mais prioritario q X -> retorna 1
    public int Compare(Tarefa? x, Tarefa? y)
    {
        if (x == null && y == null) return 0;

        if (x != null && y == null) return -1;

        if (x == null && y != null) return 1;

        if (x!.BurstTime == y!.BurstTime)
        {
            if (x.ArrivalInstant == y.ArrivalInstant) return 0;

            if (x.ArrivalInstant < y.ArrivalInstant) return -1;

            return 1;
        }

        if (x.BurstTime < y.BurstTime) return -1;

        return 1;
    }
}
