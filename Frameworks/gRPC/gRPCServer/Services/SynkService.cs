using Grpc.Core;
using static gRPCServer.Synk;

namespace gRPCServer.Services;

public class SynkService : SynkBase
{
    public override Task<TestResponseModel> GetTest(TestRequestModel request, ServerCallContext context)
    {
        return Task.FromResult(new TestResponseModel
        {
            Id = 10
        });
    }
}
