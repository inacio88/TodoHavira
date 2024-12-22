using Todo.Api.Common.Api;
using Todo.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
// builder.Services.AddDbContext<AppDbContext>(options =>
// {
//     options.UseSqlServer(ConnectionString);
// });
builder.AddConfiguration();
builder.AddDataContexts();
builder.AddJwtAuthentication();
builder.AddDocumentation();
builder.AddServices();
var app = builder.Build();


// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
app.ConfigureDevEnviroment();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapEndpoints();

app.Run();
