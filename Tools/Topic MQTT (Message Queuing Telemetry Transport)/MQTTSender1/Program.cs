using MQTTnet;
using System.Buffers;
using System.Text.Json;

namespace MQTTSender1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var clientId = "MQTTSender1";
            var factory = new MqttClientFactory();
            var mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithClientId(clientId)
                .WithTcpServer("test.mosquitto.org", 1883)
                .WithCleanSession()
                .Build();

            mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                var payload = e.ApplicationMessage.Payload;
                var json = System.Text.Encoding.UTF8.GetString(payload.ToArray());
                var message = JsonSerializer.Deserialize<DemoMessage>(json);
                
                Console.WriteLine($"MQTT 1 {clientId} received: {message?.Content} at {message?.Timestamp}");
                
                return Task.CompletedTask;
            };

            await mqttClient.ConnectAsync(options);
            await mqttClient.SubscribeAsync(MqttTopics.DemoTopic);
            Console.WriteLine($"MQTT 1 {clientId} subscribed to {MqttTopics.DemoTopic}");

            await Task.Delay(-1); // keep running
        }
    }
}
