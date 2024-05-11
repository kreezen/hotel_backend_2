using MediatR;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/customers/search/{name}", async (String name, ISender sender) =>
        {
            var query = new SearchByCustomerQuery
            {
                SearchString = name
            };
            var result = await sender.Send(query);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });

        app.MapPost("api/customers/create", async (CreateCustomerCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });

        app.MapPost("api/customers/update", async (UpdateCustomerCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });

        app.MapDelete("api/customers/delete/{id}", async (Guid id, ISender sender) =>
        {
            var command = new DeleteCustomerCommand
            {
                Id = id
            };
            var result = await sender.Send(command);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });

        app.MapGet("api/customers", async (ISender sender) =>
        {
            var query = new GetAllCustomersQuery();
            var result = await sender.Send(query);
            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        });
    }
}