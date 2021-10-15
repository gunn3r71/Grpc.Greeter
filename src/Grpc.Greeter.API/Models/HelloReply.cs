namespace Grpc.Greeter.API.Models
{
    public class HelloReply
    {
        public string Message { get; set; }
        public ServerInfoReply ServerInfo { get; set; }
    }
}