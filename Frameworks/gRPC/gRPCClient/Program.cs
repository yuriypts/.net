using Grpc.Core;
using Grpc.Net.Client;
using gRPCServer;

namespace gRPCClient;

public class Program
{
    private const string host = "https://localhost:7093";

    static async Task Main(string[] args)
    {
        var channel = GrpcChannel.ForAddress(host);

        //var greeterInput = new HelloRequest
        //{
        //    Name = "World"
        //};
        //var channel = Grpc.Net.Client.GrpcChannel.ForAddress(host);
        //var greeterClient = new Greeter.GreeterClient(channel);

        //var greeterReply = await greeterClient.SayHelloAsync(greeterInput);
        //Console.WriteLine("Greeting: " + greeterReply.Message);
        
        var eleksClient = new Eleks.EleksClient(channel);
        InfoRequest infoRequest = new()
        {
            Name = "Eleks"
        };
        var eleksResponse = await eleksClient.GetIfnoAsync(infoRequest);

        Console.WriteLine(eleksResponse.Message);

        Console.WriteLine(new string('-', 50));

        var personInput = new PersonRequestModel
        {
            UserId = 1
        };
        var personClient = new Person.PersonClient(channel);
        var replyPerson = await personClient.GetPersonInfoAsync(personInput);
        Console.WriteLine("Person: " + replyPerson.FirstName);
        Console.WriteLine("Person: " + replyPerson.LastName);
        Console.WriteLine("Person: " + replyPerson.Email);
        Console.WriteLine("Person: " + replyPerson.Age);

        

        using (var call = personClient.GetStreamPersons(new NewPersonRequestModel()))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var person = call.ResponseStream.Current;
                Console.WriteLine("Stream Person: " + person.FirstName);
                Console.WriteLine("Stream Person: " + person.LastName);
                Console.WriteLine("Stream Person: " + person.Email);
                Console.WriteLine("Stream Person: " + person.Age);
            }
        }

        Console.WriteLine(new string('-', 50));

        var replyPersons = await personClient.GetListPersonsAsync(new NewPersonRequestModel());
        foreach (var person in replyPersons.Persons)
        {
            Console.WriteLine("Person: " + person.FirstName);
            Console.WriteLine("Person: " + person.LastName);
            Console.WriteLine("Person: " + person.Email);
            Console.WriteLine("Person: " + person.Age);
        }

        Console.ReadLine();
    }
}
