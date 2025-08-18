namespace MQTTSender2;

public class MqttTopics
{
    public const string DemoTopic = "demo/messages";
}

public record DemoMessage(string Sender, string Content, DateTime Timestamp);

