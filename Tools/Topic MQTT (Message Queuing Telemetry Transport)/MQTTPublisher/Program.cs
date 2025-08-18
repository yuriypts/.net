using MQTTnet;
using System.Net.Sockets;
using System.Text.Json;

namespace MQTTPublisher
{
    internal class Program
    {
        const string Broker = "test.mosquitto.org";
        const int Port = 1883;

        static async Task Main(string[] args)
        {
            var factory = new MqttClientFactory();

            using (var mqttClient = factory.CreateMqttClient())
            {
                var options = new MqttClientOptionsBuilder()
                    .WithClientId("publisher-client")
                    .WithTcpServer(Broker, Port, AddressFamily.Unspecified)
                    .WithCleanSession()
                    .Build();

                await mqttClient.ConnectAsync(options);

                Console.WriteLine("Publisher connected");

                int count = 0;

                for (int i = 0; i < 5; i++)
                {
                    var msg = new DemoMessage("Publisher", $"Hello {count++}", DateTime.UtcNow);

                    var appMsg = new MqttApplicationMessageBuilder()
                        .WithTopic(MqttTopics.DemoTopic)
                        .WithPayload(JsonSerializer.Serialize(msg))
                        .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                        .Build();

                    await mqttClient.PublishAsync(appMsg);

                    Console.WriteLine($"Published: {msg.Content}");

                    await Task.Delay(2000);
                }

                //while (true)
                //{
                //    var msg = new DemoMessage("Publisher", $"Hello {count++}", DateTime.UtcNow);

                //    var appMsg = new MqttApplicationMessageBuilder()
                //        .WithTopic(MqttTopics.DemoTopic)
                //        .WithPayload(JsonSerializer.Serialize(msg))
                //        .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                //        .Build();

                //    await mqttClient.PublishAsync(appMsg);

                //    Console.WriteLine($"Published: {msg.Content}");

                //    await Task.Delay(2000);
                //}
            }
        }
    }
}
