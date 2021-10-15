using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Greeter.API.Models;

namespace Grpc.Greeter.API.Services
{
    public interface IGreeterService
    {
        Task<HelloReply> SayHelloAsync(string name);
    }
}
