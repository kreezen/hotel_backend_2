using MediatR;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/users/create", async (CreateUserCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });

        app.MapGet("api/users/{username}", async (String username, ISender sender) =>
        {
            var query = new GetByUsernameQuery
            {
                Username = username
            };
            var result = await sender.Send(query);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });

        app.MapGet("api/users", async (ISender sender) =>
        {
            var query = new GetAllUsersQuery();
            var result = await sender.Send(query);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });

        app.MapGet("api/users/search/{username}", async (String username, ISender sender) =>
        {
            var query = new SearchByUserQuery
            {
                Username = username
            };
            var result = await sender.Send(query);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });
    }
}