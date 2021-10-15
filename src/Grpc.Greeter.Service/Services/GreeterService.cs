using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Grpc.Greeter.Service.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        //M�todo que recebe o request e realiza a a��o solicitada
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name,
                ServerInfo = new ServerInfoReply
                {
                    Date = DateTime.UtcNow.AddHours(-3).ToString("dd/MM/yyyy"),
                    Hour = DateTime.UtcNow.AddHours(-3).ToString("HH:mm"),
                    Os = Environment.OSVersion.Platform.ToString()
                }
            });
        }
    }
}
