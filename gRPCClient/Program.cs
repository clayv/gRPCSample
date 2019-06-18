using System;
using Grpc.Core;

namespace gRPCSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel($"{gRPCSampleCommon.Host}:{gRPCSampleCommon.Port}", ChannelCredentials.Insecure);
            try
            {
                var client = new gRPCSampleService.gRPCSampleServiceClient(channel);
                var response = client.GetOrganization(new OrganizationRequest { Id = -1 });
                foreach(Organization org in response.OrganizationList)
                {
                    Console.WriteLine($"Org Name: '{org.Name}' with an ID of: {org.Id}");
                }
            }
            finally
            {
                channel.ShutdownAsync().Wait();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
