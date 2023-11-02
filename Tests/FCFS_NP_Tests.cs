using Schen.Code;
using NUnit.Framework;
using FluentAssertions;

namespace Schen.Tests;

public class FCFS_NP_Tests
{
    [Test]
    public void FCFS_NP_Tests_00()
    {
        // Arrange
        var tarefas = new List<Tarefa>
        {
            { new Tarefa { Name = "Play music", ArrivalTime = 0, BurstTime = 4, } },
        };

        var scheduler = new FCFS_NP(tarefas);

        // Act
        scheduler.Run();

        // Assert
        tarefas[0].WaitingTime.Should().Be(0);
        tarefas[0].StartTime.Should().Be(0);
        //
        scheduler.AverageWaitingTime.Should().Be(0.00M);
        //
        tarefas.ForEach(x => x.CpuTime.Should().Be(x.BurstTime));
    }

    [Test]
    public void FCFS_NP_Tests_01()
    {
        // Arrange
        var tarefas = new List<Tarefa>
        {
            { new Tarefa { Name = "Play music", ArrivalTime = 0, BurstTime = 4, } },
            { new Tarefa { Name = "Print PDF", ArrivalTime = 1, BurstTime = 3, } },
        };

        var scheduler = new FCFS_NP(tarefas);

        // Act
        scheduler.Run();

        // Assert
        tarefas[0].WaitingTime.Should().Be(0);
        tarefas[0].StartTime.Should().Be(0);
        //
        tarefas[1].WaitingTime.Should().Be(3);
        tarefas[1].StartTime.Should().Be(4);
        //
        scheduler.AverageWaitingTime.Should().Be(1.50M);
        //
        tarefas.ForEach(x => x.CpuTime.Should().Be(x.BurstTime));
    }

    [Test]
    public void FCFS_NP_Tests_02()
    {
        // Arrange
        var tarefas = new List<Tarefa>
        {
            { new Tarefa { Name = "Play music", ArrivalTime = 0, BurstTime = 4, } },
            { new Tarefa { Name = "Print PDF", ArrivalTime = 1, BurstTime = 3, } },
            { new Tarefa { Name = "Send email", ArrivalTime = 2, BurstTime = 1, } },
        };

        var scheduler = new FCFS_NP(tarefas);

        // Act
        scheduler.Run();

        // Assert
        tarefas[0].WaitingTime.Should().Be(0);
        tarefas[0].StartTime.Should().Be(0);
        //
        tarefas[1].WaitingTime.Should().Be(3);
        tarefas[1].StartTime.Should().Be(4);
        //
        tarefas[2].WaitingTime.Should().Be(5);
        tarefas[2].StartTime.Should().Be(7);
        //
        scheduler.AverageWaitingTime.Should().Be(2.67M);
        //
        tarefas.ForEach(x => x.CpuTime.Should().Be(x.BurstTime));
    }

    [Test]
    public void FCFS_NP_Tests_03()
    {
        // Arrange
        var tarefas = new List<Tarefa>
        {
            { new Tarefa { Name = "Play music", ArrivalTime = 0, BurstTime = 4, } },
            { new Tarefa { Name = "Print PDF", ArrivalTime = 1, BurstTime = 3, } },
            { new Tarefa { Name = "Send email", ArrivalTime = 2, BurstTime = 1, } },
            { new Tarefa { Name = "Open browser", ArrivalTime = 3, BurstTime = 2, } },
        };

        var scheduler = new FCFS_NP(tarefas);

        // Act
        scheduler.Run();

        // Assert
        tarefas[0].WaitingTime.Should().Be(0);
        tarefas[0].StartTime.Should().Be(0);
        //
        tarefas[1].WaitingTime.Should().Be(3);
        tarefas[1].StartTime.Should().Be(4);
        //
        tarefas[2].WaitingTime.Should().Be(5);
        tarefas[2].StartTime.Should().Be(7);
        //
        tarefas[3].WaitingTime.Should().Be(5);
        tarefas[3].StartTime.Should().Be(8);
        //
        scheduler.AverageWaitingTime.Should().Be(3.25M);
        //
        tarefas.ForEach(x => x.CpuTime.Should().Be(x.BurstTime));
    }

    [Test]
    public void FCFS_NP_Tests_04()
    {
        // Arrange
        var tarefas = new List<Tarefa>
        {
            { new Tarefa { Name = "Play music", ArrivalTime = 0, BurstTime = 4, } },
            { new Tarefa { Name = "Print PDF", ArrivalTime = 1, BurstTime = 3, } },
            { new Tarefa { Name = "Send email", ArrivalTime = 2, BurstTime = 1, } },
            { new Tarefa { Name = "Open browser", ArrivalTime = 3, BurstTime = 2, } },
            { new Tarefa { Name = "Download torrent", ArrivalTime = 4, BurstTime = 5, } },
        };

        var scheduler = new FCFS_NP(tarefas);

        // Act
        scheduler.Run();

        // Assert
        tarefas[0].WaitingTime.Should().Be(0);
        tarefas[0].StartTime.Should().Be(0);
        //
        tarefas[1].WaitingTime.Should().Be(3);
        tarefas[1].StartTime.Should().Be(4);
        //
        tarefas[2].WaitingTime.Should().Be(5);
        tarefas[2].StartTime.Should().Be(7);
        //
        tarefas[3].WaitingTime.Should().Be(5);
        tarefas[3].StartTime.Should().Be(8);
        //
        tarefas[4].WaitingTime.Should().Be(6);
        tarefas[4].StartTime.Should().Be(10);
        //
        scheduler.AverageWaitingTime.Should().Be(3.80M);
        //
        tarefas.ForEach(x => x.CpuTime.Should().Be(x.BurstTime));
    }
}
