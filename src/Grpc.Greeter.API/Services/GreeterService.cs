using System.Threading.Tasks;
using HelloReply = Grpc.Greeter.API.Models.HelloReply;
using HelloRequest = Grpc.Greeter.Service.HelloRequest;
using ServiceInfoReply = Grpc.Greeter.API.Models.ServerInfoReply;

namespace Grpc.Greeter.API.Services
{
    public class GreeterService : IGreeterService
    { 
        //Importando client do protobuf
        private readonly Service.Greeter.GreeterClient _greeterClient;

        public GreeterService(Service.Greeter.GreeterClient greeterClient)
        {
            _greeterClient = greeterClient;
        }

        //Utiliza o client para fazer o rpc
        public async Task<HelloReply> SayHelloAsync(string name)
        {
            //requisição
            var result = await _greeterClient.SayHelloAsync(new HelloRequest
            {
                Name = name
            });

            //set de model local
            var reply = new HelloReply
            {
                Message = result.Message,
                ServerInfo = new ServiceInfoReply
                {
                    Date = result.ServerInfo.Date,
                    Hour = result.ServerInfo.Hour,
                    Os = result.ServerInfo.Os
                }
            };

            return reply;
        }
    }
}