using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class CreateANPR_IncomingRequestsEndpoint
{
    internal static RouteHandlerBuilder MapANPR_IncomingRequestsCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateANPR_IncomingRequestsCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateANPR_IncomingRequestsEndpoint))
            .WithSummary("creates a ANPR_IncomingRequests")
            .WithDescription("creates a ANPR_IncomingRequests")
            .Produces<CreateANPR_IncomingRequestsResponse>()
            .RequirePermission("Permissions.ANPR_IncomingRequests.Create")
            .MapToApiVersion(1);
    }
}
