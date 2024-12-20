using Todo.Api.Common.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
builder.AddConfiguration();

builder.AddDataContexts();

builder.AddDocumentation();
builder.AddServices();

app.UseHttpsRedirection();

app.ConfigureDevEnviroment();

app.Run();
