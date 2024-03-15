

using Domain.Users;
using MediatR;
using SharedKernel;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureMinimalApi(services: builder.Services);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("api/users", async (CreateUserCommand command, ISender sender) =>
{
    Result<User> result = await sender.Send(command);
    return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
});
app.MapGet("api/users/{username}", async (GetByUsernameQuery command, ISender sender) =>
{
    Result<User> result = await sender.Send(command);
    return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
});
app.Run();
