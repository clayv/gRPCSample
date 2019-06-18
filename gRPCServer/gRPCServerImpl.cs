using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Grpc.Core;

namespace gRPCSample
{
    internal class gRPCServerImpl : gRPCSampleService.gRPCSampleServiceBase
    {
        Organization[] organizations = new Organization[]
        {
            new Organization(){ Name = "Organization 1", Id = 1 },
            new Organization(){ Name = "Organization 2", Id = 2},
            new Organization(){ Name = "Organization 3", Id = 3},
        };

        public override Task<OrganizationsResponse> GetOrganization(OrganizationRequest request, ServerCallContext context)
        {
            OrganizationsResponse response = new OrganizationsResponse();
            if (request.Id == -1)
            {
                response.OrganizationList.AddRange(organizations);
            }
            else
            {
                response.OrganizationList.Add(organizations.Where(o => o.Id == request.Id));
            }
            return Task.FromResult(response);
        }
    }
}
