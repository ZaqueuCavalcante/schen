namespace Schen.Code;

// Shortest Job First | (Non- preemptive)
public class SJF_NP
{
    public decimal AverageWaitingTime { get; set; }
    private List<Tarefa> Tarefas { get; set; }
    private PriorityQueue<Tarefa, Tarefa> Fila { get; set; }
    private Tarefa? Current { get; set; }

    public SJF_NP(List<Tarefa> tarefas)
    {
        Tarefas = tarefas;
        Fila = new PriorityQueue<Tarefa, Tarefa>(new TaskComparer());
        Current = null;
    }

    public void Run()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            // Verificar se tem e enfileirar nova tarefa
            var novaTarefa = Tarefas.FirstOrDefault(x => x.ArrivalInstant == i);
            if (novaTarefa != null)
            {
                Fila.Enqueue(novaTarefa, novaTarefa);
            }

            // Se a CPU ta livre, pega o proximo da fila pra ser executado
            if (Current == null)
            {
                Current = Fila.Count != 0 ? Fila.Dequeue() : null;

                if (Current == null) // N tem mais o que processar
                {
                    break;
                }

                Current.StartInstant = i;
            }

            // Simula que passou 1 ms sendo executado na CPU
            Current.CpuTime ++;

            // Se ja terminou de processar, sai da CPU
            if (Current.CpuTime == Current.BurstTime)
            {
                Current.CompletionInstant = i + 1;
                Current.TurnAroundTime = Current.CompletionInstant - Current.ArrivalInstant;
                Current = null;
            }
        }

        foreach (var tarefa in Tarefas)
        {
            tarefa.WaitingTime = tarefa.StartInstant - tarefa.ArrivalInstant;
        }

        var sum = Convert.ToDecimal(Tarefas.Sum(x => x.WaitingTime));
        var count = Convert.ToDecimal(Tarefas.Count);
        AverageWaitingTime = Convert.ToDecimal((sum/count).ToString("0.##"));
    }
}
