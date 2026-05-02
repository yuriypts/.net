using Grpc.Core;
using static gRPCServer.Person;

namespace gRPCServer.Services;

public class PersonService : PersonBase
{
    private readonly ILogger<PersonService> _logger;

    public PersonService(ILogger<PersonService> logger)
    {
        _logger = logger;
    }

    public override Task<PersonResponseModel> GetPersonInfo(PersonRequestModel request, ServerCallContext context)
    {
        PersonResponseModel reply = new();

        switch (request.UserId)
        {
            case 1:
                reply.FirstName = "Alice";
                reply.LastName = "Smith";
                reply.Email = "asd@asd.com";
                reply.Age = 25;
                break;
            default:
                reply.FirstName = "John";
                reply.LastName = "Doe";
                reply.Email = "test@test.com";
                reply.Age = 30;
                break;
        }

        return Task.FromResult(reply);
    }

    public override async Task GetStreamPersons(NewPersonRequestModel request, IServerStreamWriter<PersonResponseModel> responseStream, ServerCallContext context)
    {
        List<PersonResponseModel> persons = new()
        {
            new PersonResponseModel()
            {
                FirstName = "Alice",
                LastName = "Smith",
                Email = "asd@asd.com",
                Age = 25
            },
            new PersonResponseModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "test@test.com",
                Age = 30
            }
        };

        foreach (var person in persons)
        {
            await Task.Delay(2000); // Simulate some delay

            await responseStream.WriteAsync(person);
        }
    }

    public override Task<PersonListResponseModel> GetListPersons(NewPersonRequestModel request, ServerCallContext context)
    {
        //PersonListResponseModel response = new()
        //{
        //    Persons = new()
        //    {
        //        new PersonResponseModel()
        //        {
        //            FirstName = "Alice",
        //            LastName = "Smith",
        //            Email = "asd@asd.com",
        //            Age = 25
        //        },
        //        new PersonResponseModel()
        //        {
        //            FirstName = "John",
        //            LastName = "Doe",
        //            Email = "test@test.com",
        //            Age = 30
        //        }
        //    }
        //};

        PersonListResponseModel response = new();
        response.Persons.Add(new PersonResponseModel
        {
            FirstName = "Alice",
            LastName = "Smith",
            Email = "asd@asd.com",
            Age = 25
        });
        response.Persons.Add(new PersonResponseModel
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "test@test.com",
            Age = 30
        });

        return Task.FromResult(response);
    }
}
