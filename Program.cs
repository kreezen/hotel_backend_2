

using MediatR;


var builder = WebApplication.CreateBuilder(args);
builder.ConfigureMinimalApi(services: builder.Services);
var app = builder.Build();
app.UseCors();
CustomerEndpoints.MapCustomerEndpoints(app);
UserEndpoints.MapUserEndpoints(app);
TaskEndpoints.MapTaskEndpoints(app);
app.Run();
