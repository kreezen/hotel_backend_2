using MediatR;

public static class TaskEndpoints
{
    public static void MapTaskEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/activities/task/create", async (CreateTaskCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });

        app.MapGet("api/activities/task", async (ISender sender) =>
        {
            var command = new GetAllTaskQuery();
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });

        app.MapPost("api/activities/task/update", async (UpdateTaskCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });
    }
}