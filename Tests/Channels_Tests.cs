using NUnit.Framework;
using System.Threading.Channels;

namespace Schen.Tests;

public class Channels_Tests
{
    [Test]
    // dotnet test --logger:"console;verbosity=detailed" --filter "FullyQualifiedName~Channels_Tests_00"
    public async Task Channels_Tests_00()
    {
        var channel = Channel.CreateUnbounded<string>();

        var producer = new Producer(channel.Writer);
        var consumer = new Consumer(channel.Reader);

        _ = Task.Factory.StartNew(async () =>
        {
            await producer.ProduceWorkAsync();
        });
        await consumer.ConsumeWorkAsync();
    }
}

public class Producer
{
    private static readonly List<string> _todos = new()
    {
        "00",
        "01",
        "02",
        "03",
        "04",
        "05",
    };
    private readonly ChannelWriter<string> _channelWriter;
    public Producer(ChannelWriter<string> channelWriter)
    {
        _channelWriter = channelWriter;
    }
    public async Task ProduceWorkAsync()
    {
        foreach (var todo in _todos)
        {  
            if (_channelWriter.TryWrite(todo))
            {
                Console.WriteLine($"Added: {todo}");
            }
            await Task.Delay(400);
        }
        _channelWriter.Complete();
    }
}

public class Consumer
{
    private readonly ChannelReader<string> _channelReader;
    public Consumer(ChannelReader<string> channelReader)
    {
        _channelReader = channelReader;
    }
    public async Task ConsumeWorkAsync()
    {
        try
        {
            while (true)
            {
                var todo = await _channelReader.ReadAsync();
                Console.WriteLine($"Completing: {todo}");
                await Task.Delay(500);
            }
        }
        catch (ChannelClosedException)
        {
            Console.WriteLine("Channel was closed");
        }
    }
}
