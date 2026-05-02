using gRPCServer;

namespace gRPCClient;

public class Program
{
    static async Task Main(string[] args)
    {
        //var input = new HelloRequest
        //{
        //    Name = "World"
        //};
        //var host = "https://localhost:7093";
        
        //var channel = Grpc.Net.Client.GrpcChannel.ForAddress(host);
        //var client = new Greeter.GreeterClient(channel);

        //var reply = await client.SayHelloAsync(input);
        //Console.WriteLine("Greeting: " + reply.Message);

        Console.ReadLine();
    }
}
