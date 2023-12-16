using Grpc;
using Grpc.Core;

namespace Grpc.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation("log this everytime");
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Rustam
            });
        }
    }
}
