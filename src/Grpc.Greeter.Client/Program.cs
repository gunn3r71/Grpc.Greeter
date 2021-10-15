using System;
using System.Threading.Tasks;
using Grpc.Greeter.Service;
using Grpc.Net.Client;

namespace Grpc.Greeter.Cliente
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Abre um canal com a url onde está a api grpc
            var channel = GrpcChannel.ForAddress("https://localhost:5002");

            //gera um novo client com o canal criado
            var client = new Service.Greeter.GreeterClient(channel);

            //faz o request
            var reply = await client.SayHelloAsync(new HelloRequest
            {
                Name=   "Lucas"
            });

            Console.WriteLine($"{reply.Message} - Data/Hora: {reply.ServerInfo.Date} {reply.ServerInfo.Hour} - OS {reply.ServerInfo.Os}");

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
