using RabbitMQ.Client;
using System.Text;

namespace RabbitSender;

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
            ClientProvidedName = "Rabbit Sender Client", // optional client name for identification
        };

        IConnection connection = await factory.CreateConnectionAsync();
        // Fix for CS1061: Use CreateChannelAsync instead of CreateModel
        IChannel channel = await connection.CreateChannelAsync(); // Ensure CreateChannelAsync is used

        await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);
        await channel.QueueDeclareAsync(queueName, durable: false, exclusive: false, autoDelete: false);
        await channel.QueueBindAsync(queueName, exchangeName, routingKey);

        for (int i = 0; i < 30; i++)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes($"Message {i + 1}");

            // Publish the message to the exchange with the specified routing key
            await channel.BasicPublishAsync(exchangeName, routingKey, messageBytes);
            
            Console.WriteLine($"Sent: Message {i + 1}");
            Thread.Sleep(1000); // Simulate some delay between messages
        }
        
        //byte[] messageBytes = Encoding.UTF8.GetBytes("Hello, RabbitMQ!");
        //await channel.BasicPublishAsync(exchangeName, routingKey, messageBytes);

        await channel.CloseAsync();
        await connection.CloseAsync();
    }
}
