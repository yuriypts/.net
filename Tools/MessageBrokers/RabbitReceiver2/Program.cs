using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitReceiver2;

internal class Program
{
    static async Task Main(string[] args)
    {
        const string exchangeName = "test_exchange";
        const string routingKey = "test_routing_key";
        const string queueName = "test_queue";

        ConnectionFactory factory = new()
        {
            //HostName = "localhost",
            //UserName = "guest",
            //Password = "guest",
            //Uri = new Uri("amqp://guest:guest@http://192.168.31.70:15672/"),
            Uri = new Uri("amqp://guest:guest@localhost:5672/"),
            ClientProvidedName = "Rabbit Receiver 2 Client", // optional client name for identification
        };

        IConnection connection = await factory.CreateConnectionAsync();
        // Fix for CS1061: Use CreateChannelAsync instead of CreateModel
        IChannel channel = await connection.CreateChannelAsync(); // Ensure CreateChannelAsync is used

        await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);
        await channel.QueueDeclareAsync(queueName, durable: false, exclusive: false, autoDelete: false);
        await channel.QueueBindAsync(queueName, exchangeName, routingKey);

        // prefetchSize - size of messages in bytes that the server will deliver to consumers before they acknowledge messages
        // prefetchCount - how many of messages we want to receive at once
        // global - if true - applies to all consumers on the channel, if false - applies only to the current consumer
        await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (sender, arg) => // event listener for received messages
        {
            var body = arg.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Received message: {0}", message);

            // Simulate processing time
            await Task.Delay(1000);

            // Acknowledge the message
            await channel.BasicAckAsync(arg.DeliveryTag, multiple: false);
        };

        // Start consuming messages from the queue
        string consumerTag = await channel.BasicConsumeAsync(queueName, autoAck: false, consumer);

        Console.ReadLine();

        await channel.BasicCancelAsync(consumerTag);
        await channel.CloseAsync();
        await connection.CloseAsync();
    }
}
