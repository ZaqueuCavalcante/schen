using Schen.Code;
using NUnit.Framework;
using FluentAssertions;

namespace Schen.Tests;

public class SJF_NP_Tests
{
    [Test]
    public void SJF_NP_Tests_00()
    {
        // Arrange
        var tarefas = new List<Tarefa>
        {
            { new Tarefa { Name = "Open browser", ArrivalInstant = 0, BurstTime = 4, } },
        };

        var scheduler = new SJF_NP(tarefas);

        // Act
        scheduler.Run();

        // Assert
        tarefas[0].WaitingTime.Should().Be(0);
        tarefas[0].StartInstant.Should().Be(0);
        tarefas[0].CompletionInstant.Should().Be(4);
        tarefas[0].TurnAroundTime.Should().Be(4);
        //
        scheduler.AverageWaitingTime.Should().Be(0.00M);
        //
        tarefas.ForEach(x => x.CpuTime.Should().Be(x.BurstTime));
    }

    [Test]
    public void SJF_NP_Tests_01()
    {
        // Arrange
        var tarefas = new List<Tarefa>
        {
            { new Tarefa { Name = "Open browser", ArrivalInstant = 0, BurstTime = 4, } },
            { new Tarefa { Name = "Play music", ArrivalInstant = 1, BurstTime = 1, } },
        };

        var scheduler = new SJF_NP(tarefas);

        // Act
        scheduler.Run();

        // Assert
        tarefas[0].WaitingTime.Should().Be(0);
        tarefas[0].StartInstant.Should().Be(0);
        tarefas[0].CompletionInstant.Should().Be(4);
        tarefas[0].TurnAroundTime.Should().Be(4);
        //
        tarefas[1].WaitingTime.Should().Be(3);
        tarefas[1].StartInstant.Should().Be(4);
        tarefas[1].CompletionInstant.Should().Be(5);
        tarefas[1].TurnAroundTime.Should().Be(4);
        //
        scheduler.AverageWaitingTime.Should().Be(1.50M);
        //
        tarefas.ForEach(x => x.CpuTime.Should().Be(x.BurstTime));
    }

    [Test]
    public void SJF_NP_Tests_02()
    {
        // Arrange
        var tarefas = new List<Tarefa>
        {
            { new Tarefa { Name = "Open browser", ArrivalInstant = 0, BurstTime = 4, } },
            { new Tarefa { Name = "Send email", ArrivalInstant = 1, BurstTime = 3, } },
            { new Tarefa { Name = "Play music", ArrivalInstant = 2, BurstTime = 1, } },
        };

        var scheduler = new SJF_NP(tarefas);

        // Act
        scheduler.Run();

        // Assert
        tarefas[0].WaitingTime.Should().Be(0);
        tarefas[0].StartInstant.Should().Be(0);
        tarefas[0].CompletionInstant.Should().Be(4);
        tarefas[0].TurnAroundTime.Should().Be(4);
        //
        tarefas[2].WaitingTime.Should().Be(2);
        tarefas[2].StartInstant.Should().Be(4);
        tarefas[2].CompletionInstant.Should().Be(5);
        tarefas[2].TurnAroundTime.Should().Be(3);
        //
        tarefas[1].WaitingTime.Should().Be(4);
        tarefas[1].StartInstant.Should().Be(5);
        tarefas[1].CompletionInstant.Should().Be(8);
        tarefas[1].TurnAroundTime.Should().Be(7);
        //
        scheduler.AverageWaitingTime.Should().Be(2.00M);
        //
        tarefas.ForEach(x => x.CpuTime.Should().Be(x.BurstTime));
    }

    [Test]
    public void SJF_NP_Tests_05()
    {
        // Arrange
        var tarefas = new List<Tarefa>
        {
            { new Tarefa { Name = "Play music", ArrivalInstant = 2, BurstTime = 6, } },
            { new Tarefa { Name = "Print PDF", ArrivalInstant = 5, BurstTime = 2, } },
            { new Tarefa { Name = "Send email", ArrivalInstant = 1, BurstTime = 8, } },
            { new Tarefa { Name = "Open browser", ArrivalInstant = 0, BurstTime = 3, } },
            { new Tarefa { Name = "Download torrent", ArrivalInstant = 4, BurstTime = 4, } },
        };

        var scheduler = new SJF_NP(tarefas);

        // Act
        scheduler.Run();

        // Assert
        tarefas[3].WaitingTime.Should().Be(0);
        tarefas[3].StartInstant.Should().Be(0);
        tarefas[3].CompletionInstant.Should().Be(3);
        tarefas[3].TurnAroundTime.Should().Be(3);
        //
        tarefas[0].WaitingTime.Should().Be(1);
        tarefas[0].StartInstant.Should().Be(3);
        tarefas[0].CompletionInstant.Should().Be(9);
        tarefas[0].TurnAroundTime.Should().Be(7);
        //
        tarefas[1].WaitingTime.Should().Be(4);
        tarefas[1].StartInstant.Should().Be(9);
        tarefas[1].CompletionInstant.Should().Be(11);
        tarefas[1].TurnAroundTime.Should().Be(6);
        //
        tarefas[4].WaitingTime.Should().Be(7);
        tarefas[4].StartInstant.Should().Be(11);
        tarefas[4].CompletionInstant.Should().Be(15);
        tarefas[4].TurnAroundTime.Should().Be(11);
        //
        tarefas[2].WaitingTime.Should().Be(14);
        tarefas[2].StartInstant.Should().Be(15);
        tarefas[2].CompletionInstant.Should().Be(23);
        tarefas[2].TurnAroundTime.Should().Be(22);
        //
        scheduler.AverageWaitingTime.Should().Be(5.20M);
        //
        tarefas.ForEach(x => x.CpuTime.Should().Be(x.BurstTime));
    }
}
