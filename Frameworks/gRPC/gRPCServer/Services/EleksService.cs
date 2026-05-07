using static gRPCServer.Eleks;

namespace gRPCServer.Services;

public class EleksService : EleksBase
{
    public override Task<InfoResponse> GetIfno(InfoRequest request, Grpc.Core.ServerCallContext context)
    {
        return Task.FromResult(new InfoResponse
        {
            Message = request.Name + "Test"
        });
    }
}
