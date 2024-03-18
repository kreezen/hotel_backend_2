

using Domain.Users;
using MediatR;
using SharedKernel;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureMinimalApi(services: builder.Services);
var app = builder.Build();
app.UseCors();

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

app.MapPost("api/customers/create", async (CreateCustomerCommand command, ISender sender) =>
{
    var result = await sender.Send(command);
    return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
});

app.MapGet("api/customers", async (ISender sender) =>
{
    var query = new GetAllCustomersQuery();
    var result = await sender.Send(query);
    return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
});


app.Run();
