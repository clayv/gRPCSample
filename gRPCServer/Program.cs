using System;
using Grpc.Core;

namespace gRPCSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server
            {
                Services = { gRPCSampleService.BindService(new gRPCServerImpl()) },
                Ports = { new ServerPort(gRPCSampleCommon.Host, gRPCSampleCommon.Port, ServerCredentials.Insecure) }
            };

            // Start server
            server.Start();

            Console.WriteLine($"gRPCServer is listening on port {gRPCSampleCommon.Port}");
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
