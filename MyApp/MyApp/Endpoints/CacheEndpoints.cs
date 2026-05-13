using MyApp.CrossCutting;
using MyApp.Models;

namespace MyApp.Endpoints;

public static class CacheEndpoints
{
    public static IEndpointRouteBuilder MapCacheEndpoints(this IEndpointRouteBuilder routes)
    {
        // Define the group with a prefix and shared metadata
        var group = routes.MapGroup("/cache")
                          .WithTags("Cache");

        // Define individual endpoints
        group.MapGet("/",
            (ICacheManager cacheManager) => GetAll(cacheManager));

        group.MapGet("/{key}", (
                string key,
                ICacheManager cacheManager
            ) => Get(key, cacheManager));

        group.MapPost("/", (
                CacheRequest cacheRequest,
                ICacheManager cacheManager
            ) => Post(cacheRequest, cacheManager));

        return routes;
    }

    private static IResult GetAll(ICacheManager cacheManager)
    {
        var results = cacheManager.GetAll();

        return Results.Ok(results);
    }

    private static IResult Get(
        string key,
        ICacheManager cacheManager)
    {
        var result = cacheManager.Get(key);

        return Results.Ok(result);
    }

    private static IResult Post(
        CacheRequest cacheRequest,
        ICacheManager cacheManager)
    {
        if (cacheRequest == null ||
                string.IsNullOrEmpty(cacheRequest.Key))
        {
            return TypedResults.BadRequest();
        }

        if (cacheManager.Get(cacheRequest.Key) != null)
        {
            return TypedResults.BadRequest();
        }

        if (string.IsNullOrEmpty(cacheRequest.Value))
        {
            return TypedResults.BadRequest();
        }

        cacheManager.Add(cacheRequest.Key, cacheRequest.Value);

        return TypedResults.Ok();
    }
}
