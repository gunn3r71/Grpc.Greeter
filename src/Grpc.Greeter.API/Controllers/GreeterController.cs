using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Grpc.Greeter.API.Services;

namespace Grpc.Greeter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreeterController : ControllerBase
    {
        //o serviço que abstrai as chamadas rpc
        private readonly IGreeterService _greeterService;

        public GreeterController(IGreeterService greeterService)
        {
            _greeterService = greeterService;
        }
        
        [HttpPost]
        public async Task<IActionResult> SayHello(string name)
        {
            var result = await _greeterService.SayHelloAsync(name);
            var response = $"Mensagem: {result.Message} - Data/Hora/SO: {result.ServerInfo.Date} {result.ServerInfo.Hour} - {result.ServerInfo.Os}";
            
            return Ok(response);
        }
    }
}
