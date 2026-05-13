using MyApp.Domain.DTO;
using MyApp.Domain.SampleModule.Services;

namespace MyApp.Endpoints;

public static class SampleEndpoints
{
    public static IEndpointRouteBuilder MapSampleEndpoints(this IEndpointRouteBuilder routes)
    {
        // Define the group with a prefix and shared metadata
        var group = routes.MapGroup("/sample")
                          .WithTags("Sample");

        // Define individual endpoints
        group.MapGet("/available",
            (IBasicSampleService basicSampleService) => basicSampleService.IsAvailable());

        group.MapGet("/{id}", (
                int id,
                ISecondaryBasicSampleService secondaryBasicSampleService
            ) => secondaryBasicSampleService.GetById(id));

        group.MapGet("/", (
                ISecondaryBasicSampleService secondaryBasicSampleService
            ) => secondaryBasicSampleService.GetAll());

        group.MapPost("/", (
            SampleDataDTO dto,
            ISecondaryBasicSampleService secondaryBasicSampleService
            ) => secondaryBasicSampleService.Add(dto));

        return routes;
    }
}